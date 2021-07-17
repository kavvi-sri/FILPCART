using Flipcart.Connections;
using Flipcart.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Flipcart.Repository
{
    public class ProductRepositoryImp 
    {
        SqlConnection con = null;
        //Creation Of Product
        public Product createProduct(Product product)
        {
             try
            {
               // con = DBConnection.CreateConnection();
               //For Connecting DB
               string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new SqlConnection(connectionString);
                //Open The Connection
                con.Open();
                //SqlCommand is a class
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_PRODUCT(NAME,DESCRIPTION,PRICE)values('" + product.NAME + "','" + product.DESCRIPTION + "','" + product.PRICE + "')", con);
               //Execute the Query
                cmd.ExecuteNonQuery();
                return product;
            }//try close
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//catch close
            // Close the Connection
            con.Close();
            return product;
        }
        // Delete Product
        public string deleteProduct(int productId)
        {
            try
            {
                //con = DBConnection.CreateConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new SqlConnection(connectionString);

                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE  FROM TBL_PRODUCT WHERE PRODUCT_ID =" + productId, con);
                //creating object for Product
                SqlDataReader sdr = cmd.ExecuteReader();
                return "Product Deleted Sucessfully:" + productId;
            }//try close
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//catch close
            return null;
        }

        public List<Product> findAllProducts()
        {
            List<Product> productsList = new List<Product>();

            try
            {
                Product theProduct = new Product();

                //con = DBConnection.CreateConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM TBL_PRODUCT", con);
                //creating object for Product

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    theProduct = new Product();
                    theProduct.PRODUCT_ID = Convert.ToInt32(sdr["PRODUCT_ID"]);
                    theProduct.NAME = Convert.ToString(sdr["NAME"]);
                    theProduct.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
                    theProduct.PRICE = Convert.ToDecimal(sdr["PRICE"]);
                    productsList.Add(theProduct);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return productsList;

        }
        public Product findProductById(int productId)
        {
            try
            {
                // con = DBConnection.CreateConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from TBL_PRODUCT WHERE PRODUCT_ID=" + productId, con);
                //creating object for Product
                Product theProduct = new Product();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    theProduct = new Product();
                    theProduct.PRODUCT_ID = Convert.ToInt32(sdr["PRODUCT_ID"]);
                    theProduct.NAME = Convert.ToString(sdr["NAME"]);
                    theProduct.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
                    theProduct.PRICE = Convert.ToDecimal(sdr["PRICE"]);
                    con.Close();
                    return theProduct;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

       
        public Product updateProduct(int productId, Product product)
        {
            try
            {
                // con = DBConnection.CreateConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE TBL_PRODUCT SET  NAME = '" + product.NAME + "', DESCRIPTION = '" + product.DESCRIPTION + "', PRICE = '" + product.PRICE + "' WHERE PRODUCT_ID =" + productId, con);
                //creating object for Product
                SqlDataReader sdr = cmd.ExecuteReader();
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public Product findproductByName(string name)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_PRODUCT WHERE NAME = '" + name + "'", con);
                con.Open();
                Product theProduct = new Product();
                SqlDataReader sdr = cmd.ExecuteReader();
                if(sdr.Read())
                {
                    theProduct = new Product();
                    theProduct.PRODUCT_ID = Convert.ToInt32(sdr["PRODUCT_ID"]);
                    theProduct.NAME = Convert.ToString(sdr["NAME"]);
                    theProduct.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
                    theProduct.PRICE = Convert.ToDecimal(sdr["PRICE"]);
                   // con.Close();
                    return theProduct;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public List<Product> findAllProductByName(string name)
        {
            List<Product> productsList = new List<Product>();

            try
            {
                Product theProduct = new Product();

                //con = DBConnection.CreateConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM TBL_PRODUCT WHERE NAME = '" + name + "'", con);
                //creating object for Product

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    theProduct = new Product();
                    theProduct.PRODUCT_ID = Convert.ToInt32(sdr["PRODUCT_ID"]);
                    theProduct.NAME = Convert.ToString(sdr["NAME"]);
                    theProduct.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
                    theProduct.PRICE = Convert.ToDecimal(sdr["PRICE"]);
                    productsList.Add(theProduct);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return productsList;

        }
        public List<Product> findAllProdcutBetweenRange(decimal minPrice, decimal maxprice)
        {
            List<Product> productsList = new List<Product>();

            try
            {
                Product theProduct = new Product();
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM TBL_PRODUCT WHERE PRICE BETWEEN '"+minPrice+"' AND '"+maxprice+"'",con);
                //creating object for Product

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    theProduct = new Product();
                    theProduct.PRODUCT_ID = Convert.ToInt32(sdr["PRODUCT_ID"]);
                    theProduct.NAME = Convert.ToString(sdr["NAME"]);
                    theProduct.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
                    theProduct.PRICE = Convert.ToDecimal(sdr["PRICE"]);
                    productsList.Add(theProduct);
                }

            }
             catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return productsList;

        }



    }


    }
    
