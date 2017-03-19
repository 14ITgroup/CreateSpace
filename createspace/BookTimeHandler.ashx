<%@ WebHandler Language="C#" Class="BookTimeHandler" %>

using System;
using System.Web;

public class BookTimeHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        HttpResponse res = context.Response;
        HttpRequest req = context.Request;
        res.ContentType = "text/plain";
        string id = context.Request.Form["id"];
        int lesid = Convert.ToInt16(id);
        try
        {
            
            
        }
        catch { }


    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}