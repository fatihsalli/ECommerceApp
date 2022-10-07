using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    //Neden ReadRepository<Customer> ı da ilave ettik? Çünkü Read Repository içindeki tüm fonksiyonların customer özelinde uygulanarak gelmesi için yaptık. ICustomerReadRepository ekleme nedenimiz ise concrete nesnenin abstract yapılanmasıdır. Dependency injectiondan (IOC Containerdan isterken) "CustomerReadRepository" talep ederken "ICustomerReadRepository" ile talep edeceğiz. IOC 
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        //ReadRepository constructorına bir değer vermemiz gerekiyor. IOC containerden "ECommerCeAPIDbContext" context adıyla temin edilir ve base'e yani ReadRepository constructorına bu gönderilir.
        public CustomerReadRepository(ECommerceAPIDbContext context) : base(context)
        {

        }
    }
}
