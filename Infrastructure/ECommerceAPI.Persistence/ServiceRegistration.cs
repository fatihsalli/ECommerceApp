using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence
{
    //IOC Container'a servislerimizi ve database'i eklemek için extension metot oluşturduk.
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString));

        }


    }
}
