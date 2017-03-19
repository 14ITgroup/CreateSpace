<%@ WebHandler Language="C#" Class="TimeGetHandler" %>

using System;
using System.Web;
using Newtonsoft.Json;

public class TimeGetHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        HttpResponse res = context.Response;
        HttpRequest req = context.Request;
        res.ContentType = "json";

        DateTime dt = DateTime.Today;

        long Lnow = TimeTrans.DateTimeToUnixTimestamp(dt);


        res.Write("{\"result\":[{\"id\":\""+Lnow.ToString()+"\"}]}");

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}