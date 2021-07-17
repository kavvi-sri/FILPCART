using Flipcart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flipcart.Repository
{
     interface IProductRepository
    {

        Product createProduct(Product product);

        Product findProductById(int productId);

        List<Product> findAllProducts();

        string deleteProduct(int productId);

        Product updateProduct(int productId, Product product);

        Product findProductByName(string name);

        List<Product> findAllProdcutByName(string name);

        List<Product> findAllProdcutBetweenRange(decimal minPrice,decimal maxPrice);

    }
}