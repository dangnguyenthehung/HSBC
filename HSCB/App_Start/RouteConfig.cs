using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HSCB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "about",
                url: "cau-chuyen-hscb/",
                defaults: new { controller = "CompanyStory", action = "Index" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "aboutus",
                url: "cau-chuyen-hscb/ve-chung-toi",
                defaults: new { controller = "CompanyStory", action = "AboutUs"},
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "developmentplan",
                url: "cau-chuyen-hscb/chien-luoc-phat-trien",
                defaults: new { controller = "CompanyStory", action = "DevelopmentPlan" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "activity",
                url: "linh-vuc-hoat-dong",
                defaults: new { controller = "ActivityField", action = "Index" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "activity1",
                url: "linh-vuc-hoat-dong/san-xuat-chan-nuoi-va-trong-trot",
                defaults: new { controller = "ActivityField", action = "FarmSystem" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "activity2",
                url: "linh-vuc-hoat-dong/xuat-nhap-khau-nong-san",
                defaults: new { controller = "ActivityField", action = "ImportExport" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "product",
                url: "san-pham/chi-tiet/{id}",
                defaults: new { controller = "Products", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "HSCB.Controllers" }
            );
            
            routes.MapRoute(
                name: "productlist",
                url: "san-pham/",
                defaults: new { controller = "Products", action = "Index"},
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "news",
                url: "tin-tuc-su-kien/hoat-dong",
                defaults: new { controller = "News", action = "Index" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "news1",
                url: "tin-tuc-su-kien/hoat-dong",
                defaults: new { controller = "News", action = "Activity" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "news2",
                url: "tin-tuc-su-kien/san-pham",
                defaults: new { controller = "News", action = "ProductNews" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "news3",
                url: "tin-tuc-su-kien/thong-cao-bao-chi",
                defaults: new { controller = "News", action = "PressRelease" },
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "newsdetails",
                url: "tin-tuc-su-kien/chi-tiet/{id}",
                defaults: new { controller = "News", action = "NewsDetails", id = UrlParameter.Optional },
                namespaces: new[] { "HSCB.Controllers" }
            );


            routes.MapRoute(
                name: "contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "Index"},
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index"},
                namespaces: new[] { "HSCB.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HSCB.Controllers" }
            );
        }
    }
}
