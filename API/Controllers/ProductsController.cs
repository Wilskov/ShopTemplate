using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return Ok(await _productRepository.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddNewProduct(string name, string category, string description, decimal price)
        {
            return await _productRepository.AddNewProduct(name, category, description, price);
        }

    }
}