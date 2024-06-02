using JunxtionTirana2.Data.Model;
using JunxtionTirana2.Data.Model.Projects;
using JunxtionTirana2.Model.ApplicationUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JunxtionTirana2.Model
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>, IApplicationDBContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProjectInterest> UserProjectInterests { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<User>()
            .Property(p => p.Skills)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            builder.Entity<Project>()
            .HasMany(p => p.Members)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserProjectInterest>()
            .HasOne(upi => upi.Project)
            .WithMany()
            .HasForeignKey(upi => upi.ProjectId);

            builder.Entity<User>()
          .Property(u => u.Skills)
          .HasConversion(
              v => string.Join(',', v),
              v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }
    }
}
