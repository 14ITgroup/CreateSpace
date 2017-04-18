<%@ WebHandler Language="C#" Class="TimeGetHandler" %>

using System;
using System.Web;
using Newtonsoft.Json;
using System.Linq;

public class TimeGetHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        HttpResponse res = context.Response;
        HttpRequest req = context.Request;
        res.ContentType = "json";
        //res.ContentType = "json";

        DateTime dt = DateTime.Today;

        long Lnow = TimeTrans.DateTimeToUnixTimestamp(dt);
        string head = "{\"result\":[";
        string midText = "";
        string end = "]}";
        using (var db = new Entities())
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var f = (from it in db.applications
                             where it.apptime == Lnow && it.state == j && it.deal == 1
                             select it).ToList();
                    if (f.Count != 0) midText += "{\"st\": 0 }";
                    else midText += "{\"st\": 1 }";
                    if (i != 6 || j != 2) midText += ",";
                }
                Lnow += 24 * 60 * 60;
            }

        }
        res.Write(head + midText + end);

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}