<%@ WebHandler Language="C#" Class="goToOffer" %>

using System;
using System.Web;

public class goToOffer : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        if (context.Request.RequestContext.RouteData.Values.ContainsKey("OfferID"))
        {

            string pageUrl = context.Request.RequestContext.RouteData.Values["pageTitle"] as string;
            context.Response.Redirect("https://clk.omgt5.com/?PID=14635&AID=764019&CID=4714676&uid=1&MID=526801&r=https%3a%2f%2fpaytm.com%2fshop%2fp%2fstag-compact-table-tennis-table-with-2-stag-club-tt-bat-and-6-tt-balls-SPOSTAG-COMPACTSTAG20133B821525E");
        }
       // ; ; context.Request.QueryString.Params["string"];
       // context.Request.Form["value"];
        //context.Response.Redirect("https://clk.omgt5.com/?PID=14635&AID=764019&CID=4714676&uid=1&MID=526801&r=https%3a%2f%2fpaytm.com%2fshop%2fp%2fstag-compact-table-tennis-table-with-2-stag-club-tt-bat-and-6-tt-balls-SPOSTAG-COMPACTSTAG20133B821525E");
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}