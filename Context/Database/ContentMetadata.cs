using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Database
{
    [MetadataType(typeof(ContentMetadata))]
    public partial class Content
    {
        
    }
    public class ContentMetadata
    {
        public int Id;

        [Display(Name = "Tiêu đề")]
        public string Title;

        public string MetaTitle;

        [Display(Name = "Mô tả")]
        public string Description;

        [Display(Name = "Ảnh chính")]
        public string Image;

        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryID;

        [Display(Name = "Nội dung")]
        public string Detail;

        public Nullable<int> Warranty;
        public Nullable<System.DateTime> CreatedDate;
        public string CreatedBy;
        public Nullable<System.DateTime> ModifiedDate;
        public string ModifiedBy;
        public string MetaKeywords;
        public string MetaDescriptions;

        [Display(Name = "Trạng thái")]
        public Nullable<bool> Status;
        public Nullable<System.DateTime> TopHot;
        public string ViewCount;
        public string Tags;
    }
}
