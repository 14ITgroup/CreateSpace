using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MainTemplate : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            int adminId = Convert.ToInt32(Session["UserId"].ToString());
            using (var db = new Entities())
            {
                admins ad = db.admins.FirstOrDefault(a => a.id == adminId);
                LikAccount.Text = ad.account;
            }
        }
        catch
        {
            //Response.Redirect("./Login.aspx");
        }
    }

    protected void LinLogout_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Write("<script>alert('注销成功');window.location.href='Login.aspx'</script>");
    }
}
