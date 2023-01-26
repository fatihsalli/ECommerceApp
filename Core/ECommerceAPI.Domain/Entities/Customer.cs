using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}