using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers;

[ApiController]
[Route("[controller]`")]
public class PrintController : ControllerBase
{
    private readonly ICompleteOrderService _completeOrderService;

    public PrintController(ICompleteOrderService completeOrderService)
    {
        _completeOrderService = completeOrderService;
    }

    [HttpGet]
    public async Task<IActionResult> PrintEnabled() => new OkObjectResult(await _completeOrderService.ProcessAsync());
}