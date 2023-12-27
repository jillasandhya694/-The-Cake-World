using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.DataLayer
{
    public class CategoryDL
    {
        // GET: CategoryDL
        private SqlConnection connection;

        public CategoryDL() 
        {
            connection = new SqlConnection("server=.;Database=E-commerce;Trusted_Connection=True;");
        }

        public List<Category_Model> GetAllCategory()
        {
            List<Category_Model> listCategory = new List<Category_Model>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllCategory");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Category_Model data = new Category_Model();
                    data.CategoryId = (int)reader["CategoryId"];
                    data.Category = (string)reader["Category"];
                    data.IsActive = (bool)reader["IsActive"];
                    listCategory.Add(data);
                }
            
            }
            connection.Close();
                return listCategory;
    
        }

        public Category_Model GetCategoryById(int CategoryId)
        {
            Category_Model data = new Category_Model();

            connection.Open();
            SqlCommand command = getSqlCommand("GetCategoryByCategoryId");
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                    data.CategoryId = (int)reader["CategoryId"];
                    data.Category = (string)reader["Category"];
                    data.IsActive = (bool)reader["IsActive"];
                    break;
                }
                
            }
            connection.Close();
            return data;

        }

        public bool InsertintoCategory(Category_Model data) 
        {
            connection.Open();
            SqlCommand command = getSqlCommand("InsertintoCategory");
            command.Parameters.AddWithValue("@Category", data.Category);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool UpdateActiveByCategoryId(int CategoryId, bool IsActive) 
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateActive_Category_ByCategoryId");
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool UpdateCategoryByCategoryId( int CategoryId, string Category)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateCategory_ByCategoryId");
            command.Parameters.AddWithValue("@Category", Category);
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }







        public List<Category_Model> GetAllActiveCategory()
        {
            List<Category_Model> listCategory = new List<Category_Model>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllActiveCategory");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Category_Model data = new Category_Model();
                    data.CategoryId = (int)reader["CategoryId"];
                    data.Category = (string)reader["Category"];
                    data.IsActive = (bool)reader["IsActive"];
                    listCategory.Add(data);
                }

            }
            connection.Close();
            return listCategory;

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