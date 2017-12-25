using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSCB.Constants
{
    public struct SiteMapKeyConstants
    {
        public const string RootNode = "Home";

        public struct ActitityField
        {
            public const string BaseNode = "ActitityField";

            public const string FarmSystem = "FarmSystem";
            public const string ImportExport = "ImportExport";
        }


        public struct CompanyStory
        {
            public const string BaseNode = "CompanyStory";

            public const string AboutUs = "AboutUs";
            public const string DevelopmentPlan = "DevelopmentPlan";
        }

        public struct Product
        {
            public const string BaseNode = "Product";

            public const string Group = "ProductGroup";
            public const string Details = "ProductDetails";
        }

        public struct News
        {
            public const string BaseNode = "News";

            public const string Activity = "ActivityNews";
            public const string ProductNews = "ProductNews";
            public const string PressRelease = "PressRelease";
            public const string Details = "NewsDetails";
        }
        public struct Contact
        {
            public const string BaseNode = "Contact";

            public const string IndexPost = "ContactIndexPost";
        }

        public struct Message
        {
            public const string BaseNode = "Message";
        }
    }
}