using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityData;
using System.Text;

/// <summary>
/// Summary description for OfferWriteHandler
/// </summary>
public class OfferWriteHandler : System.Web.Routing.IRouteHandler
{
	public OfferWriteHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}

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

                Int64 offID = Convert.ToInt64(context.Request.RequestContext.RouteData.Values["OfferID"]);
                using (Ad_ConnectionString model = new Ad_ConnectionString())
                {
                    var url = (from u in model.Adv_Offers
                               where u.OfferID == offID
                               select u).SingleOrDefault();
                    context.Response.ContentType = "text/plain";
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("<html>");
                    sb.AppendFormat("<title>" + url.Title + "</title>");
                    sb.AppendFormat("<body>");
                    sb.AppendFormat("<img src='" + url.Adv_Mst_Merchant.LogoUrl + "'>");
                    //sb.Append("<html>");
                    //sb.Append("<html>");
                    sb.AppendFormat("</body>");
                    sb.AppendFormat("</html>");
                    context.Response.Write(sb.ToString());
                }
              
            }
            

        }
    }
}