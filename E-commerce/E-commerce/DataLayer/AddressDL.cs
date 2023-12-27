using E_commerce.Models;
using Models;
using System;
using System.Data.SqlClient;

namespace E_commerce.DataLayer
{
    public class AddressDL
    {
        // GET: AddressDL
        private SqlConnection connection;

        public AddressDL()
        {
            connection = new SqlConnection("server=.;Database=E-commerce;Trusted_Connection=True;");
        }
        public object GetAllAddressByUserId(int UserId)
        {
            Address_ModelTest data = new Address_ModelTest();
            connection.Open();
            SqlCommand command = getSqlCommand("GetAddress_ByUserID");
            command.Parameters.AddWithValue("@UserId", UserId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.AddressId = (int)reader["AddressId"];
                    data.Address = (string)reader["Address"];
                    data.Pincode = (Int64)reader["Pincode"];
                    data.UserId = (int)reader["UserId"];
                    data.IsDefault = (bool)reader["IsDefault"];
                    data.CityId = (int)reader["CityId"];
                    data.StateId = (int)reader["StateId"];
                    break;
                }
            }
            connection.Close();
            return data;
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