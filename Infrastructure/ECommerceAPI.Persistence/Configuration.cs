using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Persistence;

internal static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            //Dotnet 6 ile gelen Microsoft.Extensions.Configuration paketini kullanıyoruz. Presentation => ECommerceAPI.API => appsetting.json dosyasını okuyabilmek için
            ConfigurationManager configurationManager = new();
            //GetCurrentDirectory klasörü => Persistence yani nerede yazdıysak kodu buradan => Presentation => ECommerceAPI.API ye ulaşıyoruz.
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                "../../Presentation/EcommerceAPI.API"));
            //Microsoft.Extensions.Configuration.Json kütüphanesi ile başka bir katmandaki dosyayı elde edebiliyoruz.
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("PostgreSQL");
        }
    }
}