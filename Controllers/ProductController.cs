using Flipcart.Models;
using Flipcart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flipcart.Controllers
{
    public class ProductController : ApiController
    {
        private ProductService ProductService;
        public ProductController()
        {
            ProductService = new ProductService();
        }

        [HttpPost]
        [Route("api/product/save")]
        public Product saveProduct([FromBody] Product product)
        {

            try
            {
                return ProductService.saveProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return product;
        }
        [HttpGet]
        [Route("api/product/GetById/{productId}")]
        public Product fetchProductById(int productId)
        {
            try
            {
                return ProductService.getProductById(productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ProductService.getProductById(productId);
        }
        [HttpGet]
        [Route("api/product/GetAll")]
        public List<Product> fetchAllProduct()
        {
            try
            {
                return ProductService.getAllProducts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        [HttpDelete]
        [Route("api/product/DeleteById/{id}")]
        public string removeProductById(int id)
        {
            try
            {
                return ProductService.deleteProductById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        [HttpPut]
        [Route("api/product/update/{id}")]
        public Product updateProductById(int id, Product product)
        {
            try
            {
                return ProductService.updateProductById(id, product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        [HttpGet]
        [Route("api/product/GetByName/{name}")]
        public Product fetchProductByName(string name)
        {
            try
            {
                return ProductService.getProductByName(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ProductService.getProductByName(name);
        }

        [HttpGet]
        [Route("api/product/GetAllProductByName/{name}")]
        public List<Product> fetchAllProductByName(string name)
        {
            try
            {
                return ProductService.getAllProductByName(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ProductService.getAllProductByName(name);
        }
        [HttpGet]
        [Route("api/product/GetAllProductBetweenRange/{minPrice}/{maxPrice}")]
        public List<Product> fetchAllProductBetweenRange(decimal minPrice,decimal maxPrice)
        {
            try
            {
                return ProductService.getAllProductBetweenRange(minPrice,maxPrice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ProductService.getAllProductBetweenRange(minPrice,maxPrice);
        }





    }//class
}//namespace
