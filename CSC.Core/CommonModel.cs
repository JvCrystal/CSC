namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommonModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommonModel()
        {
            Articles = new HashSet<Article>();
            Attachments = new HashSet<Attachment>();
        }

        [Key]
        public int ModelID { get; set; }

        public int CategoryID { get; set; }

        public string Model { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Inputer { get; set; }

        public int Hits { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Status { get; set; }

        [StringLength(255)]
        public string DefaultPicUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attachment> Attachments { get; set; }

        public virtual Category Category { get; set; }
    }
}
