using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace SecondAPIProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("connExamen", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");
            modelBuilder.Entity<IdentityRole>()
              .ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>()
              .ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>()
              .ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>()
              .ToTable("UserLogin");

        }
    }

}
