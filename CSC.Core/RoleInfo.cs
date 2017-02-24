namespace CSC.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleInfo")]
    public partial class RoleInfo
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string IsActive { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
