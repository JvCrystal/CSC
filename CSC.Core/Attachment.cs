namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Attachment
    {
        public int AttachmentID { get; set; }

        public int? ModelID { get; set; }

        public string Owner { get; set; }

        public string Extension { get; set; }

        public string FileParth { get; set; }

        public DateTime UploadDate { get; set; }

        public string Type { get; set; }

        public virtual CommonModel CommonModel { get; set; }
    }
}
