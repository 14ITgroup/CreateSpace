using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ContactList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int RpC = 0;
            try
            {
                RpC = Convert.ToInt32(Request.QueryString["Rpc"]);
            }
            catch
            {
            }

            using (var db = new Entities())
            {

                if (RpC == 1 || RpC == 2)
                {
                    var dt = (from it in db.usercontact
                              where it.usclass == RpC - 1
                              select it).ToList();
                    RptCon.DataSource = dt;
                    RptCon.DataBind();
                    DdlCon.SelectedValue = RpC.ToString();
                }
                else
                {
                    var dt = (from it in db.usercontact
                              select it).ToList();
                    RptCon.DataSource = dt;
                    RptCon.DataBind();
                }
            }
        }
    }

    protected void DdlCon_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ContactList.aspx?Rpc=" + DdlCon.SelectedValue.ToString());
    }

    protected void RptCon_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int Cid = 0;
        try
        {
            Cid = Convert.ToInt32(e.CommandArgument);
        }
        catch
        {
            return;
        }
        if (e.CommandName == "del")
        {
            using(var db = new Entities())
            {
                usercontact uc = db.usercontact.FirstOrDefault(a => a.id == Cid);
                db.usercontact.Remove(uc);
                db.SaveChanges();
                Response.Write("<script>alert('删除成功');window.location.href='ContactList.aspx'</script>");
            }
        }
    }
}