using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productReadRepository.GetByIdAsync("027455bb-2b8b-4858-9614-0a83bd007867",false);
            product.Name = "Veli";
            await _productWriteRepository.SaveAsync();

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product=await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }




    }
}
