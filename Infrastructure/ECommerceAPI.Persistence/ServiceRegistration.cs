using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        //IOC Containera bu katmandan istediğimiz nesneyi koymak için extension metot oluşturuyoruz. Sonrasında bu metodu Program.cs yani program ilk ayağa kaldırılırken tetiklememiz gerekmektedir.
        //Configuration.ConnectionString bize Presentation içerisindeki appsettings.json dosyasında yer alan "conncetion strings" ifadesini bize getirecektir.
        public static void AddPersistenceServices(this IServiceCollection services) 
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer (Configuration.ConnectionString));
        }



    }
}
