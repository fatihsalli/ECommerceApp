using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        //Constructorda context istediği için bunu "(ECommerceDbContext context)" ile IOC Containerdan alarak base'e yani ReadRepository'e iletiyoruz.
        public CustomerReadRepository(ECommerceDbContext context) : base(context)
        {

        }
    }
}
