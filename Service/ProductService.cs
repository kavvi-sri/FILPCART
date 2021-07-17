using Flipcart.Models;
using Flipcart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flipcart.Service
{
    public class ProductService
    {
        private ProductRepositoryImp productRepositoryImp;
        public ProductService()
        {
            productRepositoryImp = new ProductRepositoryImp();
        }


        public Product saveProduct(Product product)
        {

            return productRepositoryImp.createProduct(product);
        }
        public Product getProductById(int productId)
        {
            return productRepositoryImp.findProductById(productId);
        }
        public List<Product> getAllProducts()
        {
            return productRepositoryImp.findAllProducts();
        }

        public string deleteProductById(int id)
        {
            return productRepositoryImp.deleteProduct(id);
        }

        public Product updateProductById(int id, Product product)
        {
            return productRepositoryImp.updateProduct(id, product);
        }

        public Product getProductByName(string name)
        {
            return productRepositoryImp.findproductByName(name);
        }

        public List<Product> getAllProductByName(string name)
        {
            return productRepositoryImp.findAllProductByName(name);
        }

        public List<Product> getAllProductBetweenRange(decimal minPrice,decimal maxprice)
        {
            return productRepositoryImp.findAllProdcutBetweenRange(minPrice, maxprice);
        }
    }

}