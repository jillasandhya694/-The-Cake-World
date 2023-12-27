

using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.DataLayer
{
    public class ProductsDL 
    {
        // GET: ProductsDL

        private SqlConnection connection;

        public ProductsDL() 
        {
            connection = new SqlConnection("server=.;Database=E-commerce;Trusted_Connection=True;");
        }

        public List<ProductsModel> GetAllProducts()
        {
            List<ProductsModel> listproducts = new List<ProductsModel>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllProducts");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductsModel data = new ProductsModel();
                    data.ProductId = (int)reader["ProductId"];
                    data.ProductName = (string)reader["ProductName"];
                    data.ProductDescription = (string)reader["ProductDescription"];
                    data.CategoryId = (int)reader["CategoryId"];
                    data.IsActive = (bool)reader["IsActive"];
                    listproducts.Add(data);

                }            
            }
            connection.Close();
                return listproducts;
        }

        public List<ProductPriceListing_Model> GetAllProductPriceListing()
        {
            List<ProductPriceListing_Model> listproductspricelist = new List<ProductPriceListing_Model>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllProductPriceListing");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductPriceListing_Model data = new ProductPriceListing_Model();
                    data.PPListId = (int)reader["PPListId"];
                    data.ProductId = (int)reader["ProductId"];
                    data.Quantity = (int)reader["Quantity"];
                    data.Measurements = (string)reader["Measurements"];
                    data.Price = (Decimal)reader["Price"];
                    listproductspricelist.Add(data);

                }
            }
            connection.Close();
            return listproductspricelist;
        }

        public List<ProductsModel> GetAllProductsByCategory(int CategoryId)
        {
            List<ProductsModel> list = new List<ProductsModel>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllProducts_ByCategory");
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductsModel data = new ProductsModel();
                    data.ProductId = (int)reader["ProductId"];
                    data.ProductName = (string)reader["ProductName"];
                    data.ProductDescription = (string)reader["ProductDescription"];
                    data.CategoryId = (int)reader["CategoryId"];
                    data.Category = (string)reader["Category"];
                    data.IsActive = (bool)reader["IsActive"];
                    list.Add(data);
                    
                }
            }
            connection.Close();
            return list;
        }

        public bool InsertintoProducttbl(ProductsModel data)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("InsertintoProducttbl");
            command.Parameters.AddWithValue("@ProductName", data.ProductName);
            command.Parameters.AddWithValue("@ProductDescription", data.ProductDescription);
            command.Parameters.AddWithValue("@CategoryId", data.CategoryId);
            command.Parameters.AddWithValue("@IsActive", data.IsActive);

            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool InsertProductPriceListing(ProductPriceListing_Model data)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("InsertProductPriceListing");
            command.Parameters.AddWithValue("@ProductId", data.ProductId);
            command.Parameters.AddWithValue("@Quantity", data.Quantity);
            command.Parameters.AddWithValue("@Measurements", data.Measurements);
            command.Parameters.AddWithValue("@Price", data.Price);

            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool UpdateActiveByProductId(bool IsActive, int ProductId) 
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateActive_Product_ByProductId");
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@ProductId", ProductId);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool UpdateProductsByProductsId(ProductsModel data)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateProduct_ByProductId");
            command.Parameters.AddWithValue("@ProductId", data.ProductId);
            command.Parameters.AddWithValue("@ProductName", data.ProductName);
            command.Parameters.AddWithValue("@ProductDescription", data.ProductDescription);
            command.Parameters.AddWithValue("@CategoryId", data.CategoryId);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool UpdateActiveProductByProductId(bool IsActive, int ProductId)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateActive_Product_ByProductId");
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@ProductId", ProductId);
            command.ExecuteNonQuery();
            connection.Close();
            return true;

        }

        public ProductsModel GetProductsById(int ProductId) 
        {
            ProductsModel data = new ProductsModel();
            connection.Open();
            SqlCommand command = getSqlCommand("GetProductsById");
            command.Parameters.AddWithValue("@ProductId", ProductId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.ProductId = (int)reader["ProductId"];
                    data.ProductName = (string)reader["ProductName"];
                    data.ProductDescription = (string)reader["ProductDescription"];
                    data.CategoryId = (int)reader["CategoryId"];
                    data.IsActive = (bool)reader["IsActive"];
                    break;
                }
            }
            connection.Close();
            return data;
        }

        public List<ProductPriceListing_Model> GetProductsPriceListById(int ProductId)
        {
            List<ProductPriceListing_Model> listPP = new List<ProductPriceListing_Model>();
            connection.Open();
            SqlCommand command = getSqlCommand("GetProductsPriceListById");
            command.Parameters.AddWithValue("@ProductId", ProductId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductPriceListing_Model data = new ProductPriceListing_Model();
                    data.PPListId = (int)reader["PPListId"];
                    data.ProductId = (int)reader["ProductId"];
                    data.Quantity = (int)reader["Quantity"];
                    data.Measurements = (string)reader["Measurements"];
                    data.Price = (Decimal)reader["Price"];
                    listPP.Add(data);
                }
            }
            connection.Close();
            return listPP;
        }

        public bool UpdateProductsPriceListByPPI(ProductPriceListing_Model data) 
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateProductsPriceListByPPId");
            command.Parameters.AddWithValue("@PPListId", data.PPListId);
            command.Parameters.AddWithValue("@Quantity", data.Quantity);
            command.Parameters.AddWithValue("@Measurements", data.Measurements);
            command.Parameters.AddWithValue("@Price", data.Price);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public List<ProductsModel> GetAllActiveProductsByCategory(int CategoryId)
        {
            List<ProductsModel> list = new List<ProductsModel>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllActiveProductsByCategoryId");
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
           
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductsModel data = new ProductsModel();
                    data.ProductId = (int)reader["ProductId"];
                    data.ProductName = (string)reader["ProductName"];
                    data.ProductDescription = (string)reader["ProductDescription"];
                    data.CategoryId = (int)reader["CategoryId"];
                    data.IsActive = (bool)reader["IsActive"];
                    data.Quantity = (int)reader["Quantity"];
                    data.Measurements = (string)reader["Measurements"];
                    data.Price = (Decimal)reader["Price"];
                    data.PPListId = (int)reader["PPListId"];
                    list.Add(data);

                }
            }
            connection.Close();
            return list;
        }


        private SqlCommand getSqlCommand(string spName)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = spName;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            return command;
        }

    }
}