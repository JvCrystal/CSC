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
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CommonModel> CommonModels { get; set; }
        public virtual DbSet<RoleInfo> RoleInfoes { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<UserProfileInfo> UserProfileInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .Property(e => e.Accounts)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.LoginIP)
                .IsUnicode(false);

            modelBuilder.Entity<RoleInfo>()
                .HasOptional(e => e.UserInfo)
                .WithRequired(e => e.RoleInfo);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.LoginIp)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .HasOptional(e => e.UserProfileInfo)
                .WithRequired(e => e.UserInfo);
        }
    }
}
