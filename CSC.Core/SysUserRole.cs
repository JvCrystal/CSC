namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysUserRole")]
    public partial class SysUserRole
    {
        [Key]
        [Column(Order = 0)]
        public Guid SysUserID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid SysRoleID { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual RoleInfo RoleInfo { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
