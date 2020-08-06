using Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Context.Extensions
{
    public class POSContext : DbContext
    {
        public POSContext()
        {
        }

        public POSContext(DbContextOptions<POSContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().
             HasKey(sc => sc.Id);
            modelBuilder.Entity<Product>().
                         HasKey(sc => sc.Id);
            modelBuilder.Entity<Role>().
                         HasKey(sc => sc.Id);
            modelBuilder.Entity<Sale>().
                         HasKey(sc => sc.Id);
            modelBuilder.Entity<User>().
                         HasKey(sc => sc.Id);
            modelBuilder.Entity<SaleProduct>().
                         HasKey(sc => sc.Id);
            modelBuilder.Entity<UserRole>().
                         HasKey(sc => new
                         { sc.UserId, sc.RoleId });
            modelBuilder.AddDataSeeding();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
