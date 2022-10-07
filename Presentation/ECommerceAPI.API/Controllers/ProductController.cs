using ECommerceAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(),Name="Product 1",Price=100,CreatedDate=DateTime.Now,Stock=10},
                new(){Id=Guid.NewGuid(),Name="Product 2",Price=60,CreatedDate=DateTime.Now,Stock=5},
                new(){Id=Guid.NewGuid(),Name="Product 3",Price=80,CreatedDate=DateTime.Now,Stock=6},
                new(){Id=Guid.NewGuid(),Name="Product 4",Price=70,CreatedDate=DateTime.Now,Stock=8},
            });
            await _productWriteRepository.SaveAsync();
        }


    }
}
