using System.Collections.Generic;
using ProductsAPI.APIDomain;

namespace ProductsAPI.Services;




public interface IProductService
{
    public IEnumerable<Product> GetAllProducts();
    Product GetProduct(int productId);
    Product AddProduct(Product productToAdd);
}