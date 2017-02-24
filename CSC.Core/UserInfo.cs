namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        public Guid ID { get; set; }

        public Guid RoleId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public string IsActive { get; set; }

        public DateTime? RegistrationTime { get; set; }

        [StringLength(15)]
        public string LoginIp { get; set; }

        public DateTime? LoginDate { get; set; }

        public virtual RoleInfo RoleInfo { get; set; }

        public virtual UserProfileInfo UserProfileInfo { get; set; }
    }
}
