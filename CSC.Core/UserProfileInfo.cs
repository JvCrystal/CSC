namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProfileInfo")]
    public partial class UserProfileInfo
    {
        [Key]
        public Guid ProfileID { get; set; }

        public string Name { get; set; }

        public bool? Sex { get; set; }

        public string Mobilephone { get; set; }

        public string Address { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
