using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;

namespace HSCB.Models
{
    public class HomePageNewsDTO
    {
        public Content NewContent { get; set; }

        public List<Content> OldContents { get; set; }
    }
}