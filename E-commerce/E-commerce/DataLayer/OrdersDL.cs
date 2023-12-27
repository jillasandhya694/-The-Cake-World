using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_commerce.DataLayer
{
    public class OrdersDL
    {
        private SqlConnection connection;

        public OrdersDL()
        {
            connection = new SqlConnection("server=.;Database=E-commerce;Trusted_Connection=True;");
        }

        public List<Orders> GetOrders(int UserId)
        {
            List<Orders> listOrders = new List<Orders>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetOrderHistory");
            command.Parameters.AddWithValue("@UserId", UserId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Orders data = new Orders();
                    data.OrderId = (int)reader["OrderId"];
                    data.UserId = (int)reader["UserId"];
                    data.OrderDate = (DateTime)reader["OrderDate"];
                    data.PaymentDate = (DateTime)reader["PaymentDate"];

                    if (reader["ModifiedDate"] != DBNull.Value)
                    {
                        data.ModifiedDate = (DateTime)reader["ModifiedDate"];
                    }
                   
                    data.Status = (int)reader["Status"];
                    data.GrandTotal = (decimal)reader["GrandTotal"];
                    data.ItemCount = (int)reader["ItemCount"];
                   
                    listOrders.Add(data);

                }
            }
            connection.Close();
            return listOrders;
        }

        public List<Orders> GetOrderItems(int OrderId)
        {
            List<Orders> listOrders = new List<Orders>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetOrderItems");
            command.Parameters.AddWithValue("@OrderId", OrderId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Orders data = new Orders();
                    data.OrderId = (int)reader["OrderId"];
                    data.ProductName = (string)reader["ProductName"];
                    data.Price = (decimal)reader["Price"];
                    data.Quantity = (int)reader["Quantity"];
                    data.TotalPrice = (decimal)reader["TotalPrice"];

                    listOrders.Add(data);

                }
            }
            connection.Close();
            return listOrders;
        }

        public List<Orders> GetOrdersByStatus(int Status)
        {
            List<Orders> listOrders = new List<Orders>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetSalesByStatus");
            command.Parameters.AddWithValue("@Status", Status);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Orders data = new Orders();
                    data.OrderId = (int)reader["OrderId"];
                    data.UserId = (int)reader["UserId"];
                    data.OrderDate = (DateTime)reader["OrderDate"];
                    data.PaymentDate = (DateTime)reader["PaymentDate"];

                    if (reader["ModifiedDate"] != DBNull.Value)
                    {
                        data.ModifiedDate = (DateTime)reader["ModifiedDate"];
                    }

                    data.Status = (int)reader["Status"];
                    data.GrandTotal = (decimal)reader["GrandTotal"];
                    data.ItemCount = (int)reader["ItemCount"];

                    listOrders.Add(data);

                }
            }
            connection.Close();
            return listOrders;
        }

        public bool UpdateStatusByOrderId(int OrderId)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateStatusByOrderId");
            command.Parameters.AddWithValue("@OrderId", OrderId);
            
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