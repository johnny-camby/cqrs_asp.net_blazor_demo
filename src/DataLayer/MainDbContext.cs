using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MainDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FullAddress> FullAddresses { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>()) 
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedWhen = DateTime.UtcNow;
                        // entry.Entity.CreateBy
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedWhen = DateTime.UtcNow;
                        //entry.Entity.ModifiedBy
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
