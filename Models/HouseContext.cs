using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyDynastyHomesAuth.Models
{
    public partial class HouseContext : DbContext
    {
        public HouseContext()
            : base("name=HouseContext")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Bathroom> Bathrooms { get; set; }
        public virtual DbSet<Exterior> Exteriors { get; set; }
        public virtual DbSet<Interior> Interiors { get; set; }
        public virtual DbSet<Kitchen> Kitchens { get; set; }
        public virtual DbSet<MyHous> MyHouses { get; set; }
        public virtual DbSet<RepairMultiplier> RepairMultipliers { get; set; }
        public virtual DbSet<Utility> Utilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
              .HasMany(e => e.MyHouses)
              .WithRequired(e => e.AspNetUser)
              .HasForeignKey(e => e.UserId);
              

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<MyHous>()
                .Property(e => e.RenovationCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MyHous>()
                .Property(e => e.BathroomCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MyHous>()
                .Property(e => e.ExteriorCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MyHous>()
                .Property(e => e.InteriorCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MyHous>()
                .Property(e => e.KitchenCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MyHous>()
                .Property(e => e.UtilitiesCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MyHous>()
                .HasOptional(e => e.Bathroom)
                .WithRequired(e => e.MyHous);

            modelBuilder.Entity<MyHous>()
                .HasOptional(e => e.Exterior)
                .WithRequired(e => e.MyHous);

            modelBuilder.Entity<MyHous>()
                .HasOptional(e => e.Interior)
                .WithRequired(e => e.MyHous);

            modelBuilder.Entity<MyHous>()
                .HasOptional(e => e.Kitchen)
                .WithRequired(e => e.MyHous);

            modelBuilder.Entity<MyHous>()
                .HasOptional(e => e.Utility)
                .WithRequired(e => e.MyHous);

   
              
        }
    }
}
