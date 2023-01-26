using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerceAPI.Persistence;

//Package Manager yerine Powershell üzerinden migration yapmak istediğimizde ECommerceDbContext constructorı doldurulamadığı için hata alıyoruz. Bu hatayı çözmek için aşağıdaki DesignTime classını oluşturmamız gerekiyor. Visual Studio ortamında çalışmadığımız durumlarda ihtiyacımız olacaktır.
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
{
    public ECommerceDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ECommerceDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
        return new ECommerceDbContext(dbContextOptionsBuilder.Options);
    }
}