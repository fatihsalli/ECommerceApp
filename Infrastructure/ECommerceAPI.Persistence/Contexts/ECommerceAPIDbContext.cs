using ECommerceAPI.Domain.Entities;
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


    }
}
