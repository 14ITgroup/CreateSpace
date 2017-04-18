using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AppContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                int appid = Convert.ToInt32(Request.QueryString["appId"]);
                using (var db = new Entities())
                {
                    var app = db.applications.First(a => a.id == appid);
                    DateTime dt = new DateTime();
                    dt=TimeTrans.UnixTimestampToDateTime(dt, app.apptime);
                    string appDate = dt.ToString("yyyy年MM月dd日");
                    string DateState = "";
                    switch (app.state)
                    {
                        case 0: DateState = "上午"; break;
                        case 1: DateState = "下午"; break;
                        case 2: DateState = "晚上"; break;
                    }
                    TxtName.Text = app.stuname;
                    TxtReason.Text = app.body;
                    TxtTile.Text = app.title;
                    LblEmail.Text = app.email;
                    LblMobile.Text = app.mobile;
                    LblTime.Text = appDate + "  " + DateState;
                    switch (app.deal)
                    {
                        case 0: BtnCanel.Visible = false; break;
                        case 1: BtnOk.Visible = false; BtnRefuse.Visible = false; break;
                        case 2: BtnCanel.Visible = false; BtnOk.Visible = false; BtnRefuse.Visible = false; break;
                    }
                }
            }
            catch
            {
                //Response.Redirect("index.aspx");
            }
        }
    }

    protected void BtnOk_Click(object sender, EventArgs e)
    {
        try
        {
            int appid = Convert.ToInt32(Request.QueryString["appId"]);
            using (var db = new Entities())
            {
                var my = db.applications.First(a => a.id == appid);
                my.deal = 1;
                db.SaveChanges();
                var failedList = (from it in db.applications
                                  where it.apptime == my.apptime && it.state == my.state && it.deal == 0
                                  select it).ToList();
                if (failedList.Count != 0)
                {
                    db.SaveChanges();
                    for (int i = 0; i < failedList.Count; i++)
                    {
                        failedList[i].deal = 2;
                        MyMail.appReMail(failedList[i]);
                    }
                    
                }
                MyMail.appReMail(my);
                MyMail.teacherMail(my);
            }
            Response.Write("<script>alert('同意成功');window.location.href='index.aspx'</script>");
        }
        catch { Response.Write("<script>alert('网络错误，请重试');</script>"); }
    }

    protected void BtnRefuse_Click(object sender, EventArgs e)
    {
        try
        {
            int appid = Convert.ToInt32(Request.QueryString["appId"]);
            using (var db = new Entities())
            {
                var my = db.applications.First(a => a.id == appid);
                my.deal = 2;
                db.SaveChanges();
                MyMail.appReMail(my);
            }
            Response.Write("<script>alert('拒绝成功');window.location.href='index.aspx'</script>");
        }
        catch { }

    }

    protected void BtnCanel_Click(object sender, EventArgs e)
    {
        try
        {
            int appid = Convert.ToInt32(Request.QueryString["appId"]);
            using (var db = new Entities())
            {
                var my = db.applications.First(a => a.id == appid);
                my.deal = 2;
                db.SaveChanges();
                MyMail.CancelMail(my);
            }
            Response.Write("<script>alert('取消成功');window.location.href='index.aspx'</script>");
        }
        catch { }
    }
}