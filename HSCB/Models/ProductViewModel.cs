using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;

namespace HSCB.Models
{
    public class ProductViewModel
    {
        public Content Content { get; set; }

        public List<Image> ImagesList { get; set; }
    }
}