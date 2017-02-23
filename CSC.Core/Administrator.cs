namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        public Guid AdministratorID { get; set; }

        [Required]
        [StringLength(30)]
        public string Accounts { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string LoginIP { get; set; }

        public DateTime? LoginTime { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
