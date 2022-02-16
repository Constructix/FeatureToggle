using Microsoft.FeatureManagement;
using ProductsAPI.APIDomain;
using ProductsAPI.Controllers;

namespace ProductsAPI.Services;

public class CompleteOrderService :ICompleteOrderService
{
    private readonly IFeatureManager _featureManager;

    public CompleteOrderService(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }
    public async Task<ToggleSettings> ProcessAsync()
    {
        var printEnabled = await _featureManager.IsEnabledAsync("Printing");
        var processOrdersEnabled = await _featureManager.IsEnabledAsync("ProcessServiceOrders");

        return new ToggleSettings()
            { PrintingEnabled = printEnabled,ProcessServiceOrdersEnabled = processOrdersEnabled };
    }
}