using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        //Bu constructor yani options IOC Container da doldurulacaktır.
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //Interceptor ile SaveChangeAsync yapmadan önce araya giriyoruz.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Track edilen verileri yakalayıp elde etmemizi sağlar.
            foreach (var data in ChangeTracker.Entries<BaseEntity>())
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        Entry(data.Entity).Property(x => x.CreatedDate).IsModified = false;
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }



    }
}
