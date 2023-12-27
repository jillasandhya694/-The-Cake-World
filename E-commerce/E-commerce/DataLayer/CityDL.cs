using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.DataLayer
{
    public class CityDL
    {
        // GET: CityDL
        private SqlConnection connection;

        public CityDL() 
        {
            connection = new SqlConnection("server=.;Database=E-commerce;Trusted_Connection=True;");
        }

        public List<City_Model> GetCity()
        {
            List<City_Model> listcity = new List<City_Model>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllCity");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                City_Model data = new City_Model();
                data.CityId = (int)reader["CityId"];
                data.CityName = (string)reader["CityName"];
                data.IsActive = (bool)reader["IsActive"];
                listcity.Add(data);
            }
            connection.Close();
                return listcity;
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