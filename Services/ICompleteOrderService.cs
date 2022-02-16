using ProductsAPI.APIDomain;

namespace ProductsAPI.Services;

public interface ICompleteOrderService
{
    public Task<ToggleSettings> ProcessAsync();
}