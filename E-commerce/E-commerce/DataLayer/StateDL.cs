using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.DataLayer
{
    public class StateDL 
    {
        // GET: StateDL
        private SqlConnection connection;

        public StateDL() 
        {
            connection = new SqlConnection("server=.; Database=E-commerce; Trusted_Connection=True;");
        }

        public List<State_Model> GetStates()
        {
            List<State_Model> liststate = new List<State_Model>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllStates");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    State_Model data = new State_Model();
                    data.StateId = (int)reader["StateId"];
                    data.StateName = (string)reader["StateName"];
                    data.IsActive = (bool)reader["IsActive"];
                    liststate.Add(data);
                }
            }
            connection.Close();
                return liststate;
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