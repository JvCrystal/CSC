namespace CSC.Core
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CSCContext : DbContext
    {
        public CSCContext()
            : base("name=CSCContext")
        {
            Database.SetInitializer<CSCContext>(new CreateDatabaseIfNotExists<CSCContext>());
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CommonModel> CommonModels { get; set; }
        public virtual DbSet<RoleInfo> RoleInfoes { get; set; }
        public virtual DbSet<SysUserRole> SysUserRoles { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<UserProfileInfo> UserProfileInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleInfo>()
                .HasMany(e => e.SysUserRoles)
                .WithRequired(e => e.RoleInfo)
                .HasForeignKey(e => e.SysRoleID);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.LoginIp)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.SysUserRoles)
                .WithRequired(e => e.UserInfo)
                .HasForeignKey(e => e.SysUserID);

            modelBuilder.Entity<UserInfo>()
                .HasOptional(e => e.UserProfileInfo)
                .WithRequired(e => e.UserInfo);
        }
    }
}
