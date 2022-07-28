using GlobalManagementSystem.Web.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GlobalManagementSystem.Web.Models;
using GlobalManagementSystem.Web.Data;

namespace GlobalManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new ConditionsSeedConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                 .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restock> Restocks { get; set; }
        public DbSet<Condition> Conditions { get; set; }
    }
}