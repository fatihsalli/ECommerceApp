using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDbContext : DbContext
    {
        //IOC Containerda DbContexti çağırabilmek için, IOC Container da doldurulması için constructor metot yazıyoruz.Bunu yazmadan IOC Containerda çağırırsak hata verir. 
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //Repository de hangi SaveChanges kullandıysak onu override ediyoruz.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar. Create,update vs. yapıldıktan sonra SaveChange methodu tetiklendiğinde bu methot araya girerek (Interceptor İşlemi) CreatedDate ve UpdatedDate güncellemelerini yapacaktır.

            var datas =ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                //_ yazarak eşitlik yazmamız halinde bu discard yapılanmasıdır. Herhangi bir atama yapılmaması için kullanılmaktadır.
                _ = data.State switch
                {
                    EntityState.Added=>data.Entity.CreatedDate=DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate=DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
