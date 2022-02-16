using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

    }
}