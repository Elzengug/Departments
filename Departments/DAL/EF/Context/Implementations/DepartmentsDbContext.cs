using System.IO;
using Departments.DAL.EF.Context.Contracts;
using Departments.DAL.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Departments.DAL.EF.Context.Implementations
{
    public sealed class DepartmentsDbContext : DbContext, IDbContext
    {
        public DepartmentsDbContext(DbContextOptions<DepartmentsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(c => c.Employees);
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();
            modelBuilder.Entity<Department>()
                .HasIndex(e => e.Name)
                .IsUnique();
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DepartmentsDbContext>
    {
        public DepartmentsDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DepartmentsDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new DepartmentsDbContext(builder.Options);
        }
    }
}
