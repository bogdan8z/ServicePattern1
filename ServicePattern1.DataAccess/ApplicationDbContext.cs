using Microsoft.EntityFrameworkCore;
using ServicePattern1.DataAccess.Interfaces;
using ServicePattern1.Domain;

namespace ServicePattern1.DataAccess
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<Order> Order { get; set; }

        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
