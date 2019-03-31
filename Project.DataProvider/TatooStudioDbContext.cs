using Microsoft.AspNet.Identity.EntityFramework;
using Project.DataProvider.Entities;
using System.Data.Entity;

namespace Project.DataProvider
{
    public class TatooStudioDbContext : IdentityDbContext<User>
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public TatooStudioDbContext()
            :base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureServiceEntity(modelBuilder);
            ConfigureOrderEntity(modelBuilder);
            ConfigureEmployeeEntity(modelBuilder);
            ConfigureIdentityEntities(modelBuilder);
          
        }

        private void ConfigureServiceEntity(DbModelBuilder modelBuilder)
        {
            var serviceConfig = modelBuilder.Entity<Service>()
                .ToTable("Servicies")
                .HasKey(x => x.Id);

            serviceConfig
                .HasMany(x => x.Orders)
                .WithRequired(x => x.Service);

            serviceConfig
                .HasMany(x => x.Employees)
                .WithMany(x => x.Services);
        }

        private void ConfigureOrderEntity(DbModelBuilder modelBuilder)
        {
            var orderConfig = modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .HasKey(x =>x.Id);

            orderConfig
                .HasRequired(x => x.Service)
                .WithMany(x => x.Orders);

            orderConfig
                .HasRequired(x => x.Employee)
                .WithMany(x => x.Orders);
        }

        private void ConfigureEmployeeEntity(DbModelBuilder modelBuilder)
        {
            var employeeConfig = modelBuilder.Entity<Employee>()
                .ToTable("Employees")
                .HasKey(x => x.Id);

            employeeConfig
                .HasMany(x => x.Orders)
                .WithRequired(x => x.Employee);

            employeeConfig
                .HasMany(x => x.Services)
                .WithMany(x => x.Employees);

        }

        private void ConfigureIdentityEntities(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles")
                .HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins")
                .HasKey(x => x.UserId);
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .Ignore(x => x.EmailConfirmed)
                .Ignore(x => x.PhoneNumberConfirmed)
                .Ignore(x => x.TwoFactorEnabled)
                .Ignore(x => x.LockoutEndDateUtc)
                .Ignore(x => x.LockoutEnabled)
                .Ignore(x => x.AccessFailedCount);
        }
    }
}
