using JwtToken.Model;
using JwtToken.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Product : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public Product(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet, Route("Getall")]
        public async Task<IActionResult> Getall(string token)
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

    }
}
