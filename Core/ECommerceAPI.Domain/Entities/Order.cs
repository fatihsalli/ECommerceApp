using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities;

public class Order : BaseEntity
{
    public string Description { get; set; }
    public string Address { get; set; }

    //Order => Product arasında çoka çok ilişki
    public ICollection<Product> Products { get; set; }

    //Order => Customer arasında bire çok ilişki
    public Customer Customer { get; set; }
    public Guid CustomerId { get; set; }
}