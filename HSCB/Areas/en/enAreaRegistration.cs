using System.Web.Mvc;

namespace HSCB.Areas.en
{
    public class enAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "en";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            #region En

            context.MapRoute(
                name: "en-about",
                url: "en/hscb-story/",
                defaults: new { controller = "CompanyStory", action = "Index" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-aboutus",
                url: "en/hscb-story/about-us",
                defaults: new { controller = "CompanyStory", action = "AboutUs" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-developmentplan",
                url: "en/hscb-story/development-plan",
                defaults: new { controller = "CompanyStory", action = "DevelopmentPlan" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-activity",
                url: "en/activity-field",
                defaults: new { controller = "ActivityField", action = "Index" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-activity1",
                url: "en/activity-field/husbandry-and-cultivation",
                defaults: new { controller = "ActivityField", action = "FarmSystem" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-activity2",
                url: "en/activity-field/import-export-agricultural",
                defaults: new { controller = "ActivityField", action = "ImportExport" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-product",
                url: "en/products/details/{id}",
                defaults: new { controller = "Products", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-productlist",
                url: "en/products/",
                defaults: new { controller = "Products", action = "Index" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-news",
                url: "en/news-events/",
                defaults: new { controller = "News", action = "Index" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-news1",
                url: "en/news-events/activity",
                defaults: new { controller = "News", action = "Activity" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-news2",
                url: "en/news-events/product",
                defaults: new { controller = "News", action = "ProductNews" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-news3",
                url: "en/news-events/press-release",
                defaults: new { controller = "News", action = "PressRelease" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-newsdetails",
                url: "en/news-events/news-details/{id}",
                defaults: new { controller = "News", action = "NewsDetails", id = UrlParameter.Optional },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );


            context.MapRoute(
                name: "en-contact",
                url: "en/contact",
                defaults: new { controller = "Contact", action = "Index" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            context.MapRoute(
                name: "en-home",
                url: "en/home",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "HSCB.Areas.en.Controllers" }
            );

            #endregion
            context.MapRoute(
                "en_default",
                "en/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}