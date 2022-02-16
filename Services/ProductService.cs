using System.Collections.Generic;
using System.Linq;
using ProductsAPI.APIDomain;

namespace ProductsAPI.Services;

public class ProductService : IProductService
{
    private readonly List<Product> products;

    public ProductService(List<Product> products)
    {
        this.products = products;
    }

    public IEnumerable<Product> GetAllProducts() => products.AsEnumerable();
    public Product GetProduct(int productId)
    {
        var foundProduct = products.Find(x => x.Id == productId);
        if(foundProduct != null)
            return foundProduct;
        else
        {
            return null;
        }
    }

    public Product AddProduct(Product productToAdd)
    {
        var lastOrderProductId = products.OrderBy(x => x.Id).LastOrDefault()!.Id;
        productToAdd.Id = lastOrderProductId + 1;
        this.products.Add(productToAdd);
        return productToAdd;
    }
}