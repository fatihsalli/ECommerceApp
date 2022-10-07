using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace ECommerceAPI.Persistence
{
    static class Configuration
    {
        //appsetting.json içinde SqlServer adıyla connection string belirliyoruz. Bu Json Presentation katmanında olduğu için "ConfigurationManager" sınıfını kullanıyoruz bunu kullanabilmek için de "Microsoft.Extensions.Configuration" kütüphanesini Persistence katmanına yüklememiz gerekiyor. Daha sonra instance alarak yolu belirtiyoruz. AddJsonFile ile de Json dosyasını ekliyoruz. AddJsonFile komutunu kullanabilmek için "Microsoft.Extensions.Configuration.Json" kütüphanesini yüklüyoruz. Bunları yapma amacımız her katmanda json dosyası oluşturmak yerine sadece Presentation katmanındaki Json dosyasını kullanarak ayarların tek bir yerde tutulmasını sağlamaktır.
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceAPI.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SqlServer");
            }
        }

    }
}
