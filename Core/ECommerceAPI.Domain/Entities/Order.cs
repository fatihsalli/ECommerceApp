using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
