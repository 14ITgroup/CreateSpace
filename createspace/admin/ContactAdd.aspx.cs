using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ContactAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int IfC = 0;
            try
            {
                IfC = Convert.ToInt32(Request.QueryString["id"]);
                using (var db = new Entities())
                {
                    var d = db.usercontact.FirstOrDefault(a => a.id == IfC);
                    TxtName.Text = d.usname;
                    TxtEmail.Text = d.usemail;
                    if (d.usclass == 0) Rad0.Checked = true;
                    else if (d.usclass == 1) Rad1.Checked = true;
                    BtnSub.Text = "修改";
                }

            }catch
            {
                
            }
        }
    }

    protected void BtnSub_Click(object sender, EventArgs e)
    {
        int IfC = 0;
        string tname = TxtName.Text.Trim();
        string temail = TxtEmail.Text.Trim();
        int level = -1;
        if (Rad0.Checked) level = 0;
        if (Rad1.Checked) level = 1;
        if (level < 0)
        {
            Response.Write("<script>alert('请选择一个权限')</script>");
            return;
        }
        else if (tname == "")
        {
            Response.Write("<script>alert('请填写姓名')</script>");
            return;
        }
        else if (temail == "")
        {
            Response.Write("<script>alert('请填写')</script>");
            return;
        }
        try
        {
            IfC = Convert.ToInt32(Request.QueryString["id"]);
            using (var db = new Entities())
            {
                
                usercontact us = db.usercontact.FirstOrDefault(a => a.id == IfC);
                var usCheck = (from it in db.usercontact
                               where it.usname == tname && it.usemail == temail && it.usclass == level
                               select it).ToList();
                if (usCheck.Count != 0)
                {
                    Response.Write("<script>alert('修改后不能跟已存在信息相同')</script>");
                    return;
                }
                us.usname = tname;
                us.usemail = temail;
                us.usclass = level;
                db.SaveChanges();
                Response.Write("<script>alert('修改成功');window.location.href='ContactList.aspx'</script>");
            }

        }
        catch
        {
            using (var db = new Entities())
            {

                usercontact us = new usercontact();
                var usCheck = (from it in db.usercontact
                               where it.usname == tname && it.usemail == temail && it.usclass == level
                               select it).ToList();
                if (usCheck.Count != 0)
                {
                    Response.Write("<script>alert('添加联系人不能跟已存在信息相同')</script>");
                    return;
                }
                us.usname = tname;
                us.usemail = temail;
                us.usclass = level;
                db.usercontact.Add(us);
                db.SaveChanges();
                Response.Write("<script>alert('添加成功');window.location.href='ContactList.aspx'</script>");
            }
        }
    }
}