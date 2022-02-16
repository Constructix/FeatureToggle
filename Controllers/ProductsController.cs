using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.APIDomain;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            if (_productService == null)
                _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            await Task.FromResult(new OkObjectResult(_productService.GetAllProducts()));

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            var product = _productService.GetProduct(productId);
            if(product != null)
                return await Task.FromResult(new OkObjectResult(product));
            else
            {
                return await Task.FromResult(new NotFoundResult());
            }
        }
        

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] Product newProductToAdd)
        {
            var newProduct = _productService.AddProduct(newProductToAdd);
            return await Task.FromResult(CreatedAtAction(nameof(Get), new {productId = newProduct.Id}, newProduct));
        }
    }
}