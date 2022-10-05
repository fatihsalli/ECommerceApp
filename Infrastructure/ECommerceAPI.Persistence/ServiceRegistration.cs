using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Persistence.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        //Extension fonksiyon yöntemi ile services oluşturulup. Presentation Api tarafında bu metotu yazarak orada tetikledik. IOC'den çekerek Concrete-ProductService içerisindeki listi controller da tetikledik.
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }




    }
}
