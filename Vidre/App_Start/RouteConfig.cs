using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidre
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            /*Instead of below way of custom routing, use Attribute routing. The newest way*/
            //routes.MapRoute(
            //    "MoviesByReleaseDate",//name must be unique
            //    "movies/released/{year}/{month}", // url pattern, paras are mentioned in curly braces
            //    new {controller = "Movies", action = "ByReleaseDate"},// defaults, represented with a anonymous object
            //    //new {year = @"\d{4}", month = @"\d{2}" },// adding constraints with regEx
            //    //year: 4 digits, month 2 digits
            //    new {year = @"2015|2016", month = @"\d{2}"}//constraint : only specific years
            //    ); 

            routes.MapRoute(
                name: "Default", 
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
