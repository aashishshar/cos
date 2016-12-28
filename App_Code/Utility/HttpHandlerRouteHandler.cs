using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using EntityData;

/// <summary>
/// Summary description for CustomRouteHandler
/// </summary>
public class RouteHandler : System.Web.Routing.IRouteHandler
{
    public IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
    {
        HttpHanler httpHandler = new HttpHanler();
        return httpHandler;
    }
    public class HttpHanler : IHttpHandler
    {

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.RequestContext.RouteData.Values.ContainsKey("OfferID"))
            {

                Int64 offID =Convert.ToInt64(context.Request.RequestContext.RouteData.Values["OfferID"]);
                using (Ad_ConnectionString model = new Ad_ConnectionString())
                {
                    var url = (from u in model.Adv_Offers
                               where u.OfferID == offID
                               select u.NavigationURL).SingleOrDefault();
                    //context.Server.Transfer(url);
                    if (url != null)
                    {
                        context.Response.Redirect(url, true);
                    }
                    else
                    {
                       Uri priURl= context.Request.UrlReferrer;
                       context.Response.Redirect(priURl.AbsoluteUri.ToString());
                    }
                }
                //

                //context.Response.Redirect("https://clk.omgt5.com/?PID=14635&AID=764019&CID=4714676&uid=1&MID=526801&r=https%3a%2f%2fpaytm.com%2fshop%2fp%2fstag-compact-table-tennis-table-with-2-stag-club-tt-bat-and-6-tt-balls-SPOSTAG-COMPACTSTAG20133B821525E");
            }
            //context.Response.ContentType = "image/jpg";
            //context.Response.WriteFile(context.Server.MapPath("~/Images/Hydrangeas.jpg"));

        }
    }
}