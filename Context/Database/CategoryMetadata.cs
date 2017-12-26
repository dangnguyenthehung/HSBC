using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Database
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {
        
    }
    public class CategoryMetadata
    {
        public int ID;

        [Display(Name = "Tên danh mục")]
        [Required]
        public string Name;

        [Display(Name = "Danh mục cha")]
        [Required]
        public string ParentID;

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
    }
}
