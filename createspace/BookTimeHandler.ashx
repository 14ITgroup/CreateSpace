<%@ WebHandler Language="C#" Class="BookTimeHandler" %>

using System;
using System.Web;
using System.Linq;

public class BookTimeHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        HttpResponse res = context.Response;
        HttpRequest req = context.Request;
        res.ContentType = "json";
        try
        {
            string bookDate = context.Request.Form["bDate"];
            long lesid = Convert.ToInt64(bookDate);
            string bookTime = context.Request.Form["bTime"];
            int bt = Convert.ToInt32(bookTime);
            string name = context.Request.Form["bName"];
            string bookEmail = context.Request.Form["bEmail"];
            string bookTitle = context.Request.Form["bTitle"];
            string bookBody = context.Request.Form["bBody"];
            string bookMobile = context.Request.Form["bMobile"];
            using (var db = new Entities())
            {
                var Check = (from it in db.applications
                             where it.apptime == lesid && it.state == bt && it.deal == 1
                             select it).ToList();
                if (Check.Count == 0)
                {
                    DateTime ddt = DateTime.Now;
                    applications app = new applications();
                    app.deal = 0;
                    app.state = bt;
                    app.apptime = lesid;
                    app.dealtime = ddt;
                    app.createtime = ddt;
                    app.email = bookEmail;
                    app.stuname = name;
                    app.title = bookTitle;
                    app.body = bookBody;
                    app.mobile = bookMobile;
                    db.applications.Add(app);
                    if (db.SaveChanges() != 0)
                    {
                        MyMail.appMail(app);
                        MyMail.adminMail();
                        res.Write("{\"state\": 1}");
                    }
                    else res.Write("{\"state\":2}");



                }
                else
                {
                    res.Write("{\"state\":3}");
                }
            }
        }
        catch
        {
            res.Write("{\"state\":0}");
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}