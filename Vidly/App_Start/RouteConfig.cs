using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); //enabling arrt rout

            /*
            //order matters. put bebore default routes. Customer route
            routes.MapRoute(
                "MoviesByReleaseDate", 
                "movies/released/{year}/{month}",    //url pattern
                new { controller = "Movies", action = "ByReleaseDate" } ,    //second parametr specify the default
                //new { year = @"\d{4}", month = @"\d{2}" }        //regular expression
                new { year = @"2017|2018", month = @"\d{2}" }
                ); */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
