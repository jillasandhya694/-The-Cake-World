using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_commerce.DataLayer
{
    public class CartDL
    {
        private SqlConnection connection;

        public CartDL()
        {
            connection = new SqlConnection("server=.;Database=E-commerce;Trusted_Connection=True;");
        }
        public bool InsertintoCartTable(CartModel PPdata)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("InsertIntoCarttbl");
            command.Parameters.AddWithValue("@UserId", 1);
            command.Parameters.AddWithValue("@ProductId", PPdata.ProductId);
            command.Parameters.AddWithValue("@PriceId", PPdata.PriceId);
            command.Parameters.AddWithValue("@Quantity", PPdata.Quantity);


            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public List<CartModel> GetCartDetails(int UserId)
        {
            List<CartModel> listCart= new List<CartModel>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetCartRecords");
            command.Parameters.AddWithValue("@UserId", UserId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CartModel data = new CartModel();
                    data.CardId = (int)reader["CardId"];
                    data.UserId = (int)reader["UserId"];
                    data.ProductId = (int)reader["ProductId"];
                    data.PriceId = (int)reader["PriceId"];
                    data.Quantity = (int)reader["Quantity"];
                    data.Status = (int)reader["Status"];
                    data.Volume = (int)reader["Volume"];
                    data.Measurements = (string)reader["Measurements"];
                    data.Price = (Decimal)reader["Price"];
                    data.ProductName = (string)reader["ProductName"];
                    data.ProductDescription = (string)reader["ProductDescription"];
                    data.TotalPrice = (Decimal)reader["TotalPrice"];
                    listCart.Add(data);

                }
            }
            connection.Close();
            return listCart;
        }

        public bool RemovefromCartTable(int CardId)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("RemoveProductfromCartByCartId");
            command.Parameters.AddWithValue("@CartId", CardId);
         
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool InsertintoOrders(int UserId)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("InsertIntoOrders");
            command.Parameters.AddWithValue("@UserId", UserId);
           
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool UpdateQuantityByCartId(int Quantity, int CardId)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateQuantityByCartId");
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@CardId", CardId);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
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