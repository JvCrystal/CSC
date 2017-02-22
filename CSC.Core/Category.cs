namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            CommonModels = new HashSet<CommonModel>();
        }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int ParentId { get; set; }

        [Required]
        public string ParentPath { get; set; }

        public string Description { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public int Type { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(255)]
        public string CategoryView { get; set; }

        [StringLength(255)]
        public string ContentView { get; set; }

        [StringLength(255)]
        public string LinkUrl { get; set; }

        public int Order { get; set; }

        public int? ContentOrder { get; set; }

        public int? PageSize { get; set; }

        [StringLength(255)]
        public string RecordUnit { get; set; }

        [StringLength(255)]
        public string RecordName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommonModel> CommonModels { get; set; }
    }
}
