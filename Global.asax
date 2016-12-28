<%@ Application Language="C#" %>

<script runat="server">

    void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute(
                "Category",
                "category/{pageTitle}",
                "~/frmsearch.aspx"
                );
        routes.MapPageRoute(
                 "Brand",
                 "Brand/{BrandName}/{BrandID}",
                 "~/frmDealByBrand.aspx"
                 );
        routes.MapPageRoute(
                 "Offer",
                 "Offer/{OfferID}",
                 "~/frmViewOffer.aspx"//, false, new System.Web.Routing.RouteValueDictionary { { "OfferID", String.Empty } }
                 );

        routes.Add(new System.Web.Routing.Route("GoToOffer/{OfferID}", new RouteHandler()));

        routes.Add(new System.Web.Routing.Route("Share/{OfferID}", new OfferWriteHandler()));
        
       // routes.Add(new System.Web.Routing.Route("{language}/{*ashx}", new HttpHandlerRouteHandler("~/goToOffer.ashx")));
   
       // String handlerPath = "~/UploadHandler.ashx";
       //routes.Add(new System.Web.Routing.Route("files/upload", new HttpHandlerRoute(handlerPath)));
    //    string[] supportedExtensions = new[] { "aspx", "ashx" };
    //routes.Add(new Microsoft.AspNet.FriendlyUrls.FriendlyUrlSettings((supportedExtensions));
        
        routes.MapPageRoute(
              "Merchant",
              "Merchant/{pageTitle}",
              "~/MerchantOffers.aspx",false,new System.Web.Routing.RouteValueDictionary { { "pageTitle", String.Empty } });
        //routes.MapPageRoute("Customers", "Customers", "~/Customers.aspx");
    }

    void Application_Start(object sender, EventArgs e)
    {
       
        // Code that runs on application startup
        Application["CurrentUserLoginInfo"] = null;
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);



    }
   
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
