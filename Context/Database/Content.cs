//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Context.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Content
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Content()
        {
            this.Images = new HashSet<Image>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Detail { get; set; }
        public Nullable<int> Warranty { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> TopHot { get; set; }
        public string ViewCount { get; set; }
        public string Tags { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }
    }
}
