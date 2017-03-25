using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            using (var db = new Entities())
            {
                if (Session["ValidateNum"].ToString() != TxtVer.Text)
                {
                    Response.Write("<script>alert('验证码错误')</script>");
                    return;
                }
                var adCheck = (from it in db.admins
                               where it.account == TxtAccount.Text
                               select it).ToList();
                if (adCheck.Count != 0)
                {
                    if (PasswordHash.PasswordHash.ValidatePassword(TxtPassword.Text, adCheck[0].password))
                    {
                        Session["UserId"] = adCheck[0].id.ToString();
                        Response.Write("<script>alert('登录成功');window.location.href='index.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('用户名或密码错误');</script>");
                    }
                }
                else Response.Write("<script>alert('用户名或密码错误');</script>");
            }
        }
        catch
        {
            Response.Write("<script>alert('网络问题，请重试')</script>");
        }
    }

    protected void BtnRegist_Click(object sender, EventArgs e)
    {
        try
        {
            using (var db = new Entities())
            {
                var adCheck = (from it in db.admins
                               where it.account == TxtAccount.Text.Trim()
                               select it).ToList();
                if (adCheck.Count != 0)
                {
                    Response.Write("<script>alert('该用户已存在');</script>");
                    return;
                }
                admins ad = new admins();
                ad.account = TxtAccount.Text.Trim();
                ad.password = PasswordHash.PasswordHash.CreateHash(TxtPassword.Text.Trim());
                ad.email = "itstudio@stu.ouc.edu.cn";
                ad.nickname = "111111111";
                db.admins.Add(ad);
                db.SaveChanges();
                Response.Write("<script>alert('注册成功');</script>");
            }
        }
        catch
        {
            Response.Write("注册失败！");
        }
    }
}