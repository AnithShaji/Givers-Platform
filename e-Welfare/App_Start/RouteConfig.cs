using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace e_Welfare
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            ////routes.MapRoute(
            ////    name: "Default",
            ////    url: "{controller}/{action}/{id}",
            ////    defaults: new { controller = "Login", action = "LoginDetails", id = UrlParameter.Optional }
            ////);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("UploadFile",
                           "FileUpload/UploadFile/",
                           new { controller = "FileUpload", action = "UploadFile" },
                           new[] { "File" });
            routes.MapRoute("UploadFileView",
                        "FileUpload/FileUploadPartialView/",
                        new { controller = "FileUpload", action = "FileUploadPartialView" });
        }
    }
}
