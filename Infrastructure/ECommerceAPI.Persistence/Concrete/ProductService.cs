using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Concrete
{
    public class ProductService : IProductService
    {
        //Target type özelliği
        public List<Product> GetProducts()
            => new() 
            { 
                new() {Id=Guid.NewGuid(),Name="Product 1",Price=100, Stock=20},
                new() {Id=Guid.NewGuid(),Name="Product 2",Price=65,Stock=20},
                new() {Id=Guid.NewGuid(),Name="Product 3",Price=25, Stock=20},
                new() {Id=Guid.NewGuid(),Name="Product 4",Price=60, Stock=20},
                new() {Id=Guid.NewGuid(),Name="Product 5",Price=80, Stock=20}
            };

    }
}
