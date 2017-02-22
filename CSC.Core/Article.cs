namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Article
    {
        public int ArticleID { get; set; }

        public int ModelID { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Source { get; set; }

        [StringLength(255)]
        public string Intro { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual CommonModel CommonModel { get; set; }
    }
}
