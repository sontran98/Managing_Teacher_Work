namespace Managing_Teacher_Work.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MTWDbContext : DbContext
    {
        public MTWDbContext()
            : base("name=MTWDbContext")
        {
        }

        public virtual DbSet<CalendarWorking> CalendarWorking { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<GroupUser> GroupUser { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Science> Science { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TypeCalendar> TypeCalendar { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Work> Work { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>()
                .HasMany(e => e.User)
                .WithOptional(e => e.GroupUser)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<GroupUser>()
                .HasMany(e => e.Role)
                .WithMany(e => e.GroupUser)
                .Map(m => m.ToTable("Credential").MapLeftKey("GroupID").MapRightKey("RoleID"));
        }
    }
}
