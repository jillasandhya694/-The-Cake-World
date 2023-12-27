using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.DataLayer
{
    public class UserDL
    { 
        // GET: UserDL
        private SqlConnection connection;

        public UserDL() 
        {
            connection = new SqlConnection("server=.; Database=E-commerce; Trusted_Connection= True;");
        }


        public List<UsersModel> GetAllUsers()
        {
            List<UsersModel> listUsers = new List<UsersModel>();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllUsers");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    UsersModel data = new UsersModel();
                    data.UserId = (int)reader["UserId"];
                    data.UserName = (string)reader["UserName"];
                    if (reader["FirstName"] != DBNull.Value)
                    {
                        data.FirstName = (string)reader["FirstName"];
                    }
                    if (reader["MiddleName"] != DBNull.Value)
                    {
                        data.MiddleName = (string)reader["MiddleName"];
                    }
                    if (reader["LastName"] != DBNull.Value)
                    {
                        data.LastName = (string)reader["LastName"];
                    }
                    if (reader["DOB"] != DBNull.Value)
                    {
                        data.DOB = (DateTime)reader["DOB"];
                    }
                    if (reader["Gender"] != DBNull.Value)
                    {
                        data.Gender = (string)reader["Gender"];
                    }
                    
                    data.PhoneNo = (Int64)reader["PhoneNo"];

                    if (reader["AdharNo"] != DBNull.Value)
                    {
                        data.AdharNo = (Int64)reader["AdharNo"];
                    }
                   
                    data.EmailId = (string)reader["EmailId"];
                    data.IsActive = (bool)reader["IsActive"];
                    data.IsDeleted = (bool)reader["IsDeleted"];
                    data.IsBlocked = (bool)reader["IsBlocked"];
                    data.Password = (string)reader["Password"];
                    listUsers.Add(data);
                }
            }
            connection.Close();
            return listUsers;
        }

        public UsersModel GetUserByUserName(string UserName) 
        {
            UsersModel data = new UsersModel();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllUsers_ByUserName");
            command.Parameters.AddWithValue("@UserName", UserName);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.UserId = (int)reader["UserId"];
                    data.UserName = (string)reader["UserName"];
                    data.FirstName = (string)reader["FirstName"];
                    data.MiddleName = (string)reader["MiddleName"];
                    data.LastName = (string)reader["LastName"];
                    data.DOB = (DateTime)reader["DOB"];
                    data.Gender = (string)reader["Gender"];
                    data.PhoneNo = (Int64)reader["PhoneNo"];
                    data.AdharNo = (Int64)reader["AdharNo"];
                    data.EmailId = (string)reader["EmailId"];
                    data.CartCount = (int)reader["CartCount"];
                    data.IsActive = (bool)reader["IsActive"];
                    data.IsDeleted = (bool)reader["IsDeleted"];
                    data.IsBlocked = (bool)reader["IsBlocked"];
                    data.Password = (string)reader["Password"];

                    break;
                }

            }
            connection.Close();
            return data;
        }

        public bool InsertintoUserstbl(UsersModel data) 
        {
            connection.Open();
            SqlCommand command = getSqlCommand("InsertintoUser_tbl");
            command.Parameters.AddWithValue("@UserName", data.UserName);
            command.Parameters.AddWithValue("@FirstName", data.FirstName);
            command.Parameters.AddWithValue("@MiddleName", data.MiddleName);
            command.Parameters.AddWithValue("@LastName", data.LastName);
            command.Parameters.AddWithValue("@DOB", data.DOB);
            command.Parameters.AddWithValue("@Gender", data.Gender);
            command.Parameters.AddWithValue("@PhoneNo", data.PhoneNo);
            command.Parameters.AddWithValue("@AdharNo", data.AdharNo);
            command.Parameters.AddWithValue("@EmailId", data.EmailId);
            command.Parameters.AddWithValue("@Password", data.Password);

            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool UpdateActiveByUserId(bool IsActive, int UserId)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateActive_User_ByUserId");
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserId", UserId);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool UpdateBlockByUserId(bool IsBlocked, int UserId)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateBlock_User_ByUserId");
            command.Parameters.AddWithValue("@IsBlocked", IsBlocked);
            command.Parameters.AddWithValue("@UserId", UserId);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        public bool UpdateUserByUserId(UsersModel data)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateUser_tbl_ById");
            command.Parameters.AddWithValue("@UserId", data.UserId);
            command.Parameters.AddWithValue("@FirstName", data.FirstName);
            command.Parameters.AddWithValue("@MiddleName", data.MiddleName);
            command.Parameters.AddWithValue("@LastName", data.LastName);
            command.Parameters.AddWithValue("@DOB", data.DOB);
            command.Parameters.AddWithValue("@Gender", data.Gender);
            command.Parameters.AddWithValue("@PhoneNo", data.PhoneNo);
            command.Parameters.AddWithValue("@AdharNo", data.AdharNo);
            

            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool InsertUserRegistration(UsersModel data) 
        {
            connection.Open();
            SqlCommand command = getSqlCommand("InsertintoUser_tbl_Registration");
            command.Parameters.AddWithValue("@UserName", data.UserName);
            command.Parameters.AddWithValue("@PhoneNo", data.PhoneNo);
            command.Parameters.AddWithValue("@EmailId", data.EmailId);
            command.Parameters.AddWithValue("@Password", data.Password);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public UsersModel GetAllUsersById(int UserId)
        {
            UsersModel data = new UsersModel();

            connection.Open();
            SqlCommand command = getSqlCommand("GetAllUsersById");
            command.Parameters.AddWithValue("@UserId",UserId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                   
                    data.UserId = (int)reader["UserId"];
                    data.UserName = (string)reader["UserName"];
                    if (reader["FirstName"] != DBNull.Value)
                    {
                        data.FirstName = (string)reader["FirstName"];
                    }
                    if (reader["MiddleName"] != DBNull.Value)
                    {
                        data.MiddleName = (string)reader["MiddleName"];
                    }
                    if (reader["LastName"] != DBNull.Value)
                    {
                        data.LastName = (string)reader["LastName"];
                    }
                    if (reader["DOB"] != DBNull.Value)
                    {
                        data.DOB = (DateTime)reader["DOB"];
                    }
                    if (reader["Gender"] != DBNull.Value)
                    {
                        data.Gender = (string)reader["Gender"];
                    }

                    data.PhoneNo = (Int64)reader["PhoneNo"];

                    if (reader["AdharNo"] != DBNull.Value)
                    {
                        data.AdharNo = (Int64)reader["AdharNo"];
                    }

                    data.EmailId = (string)reader["EmailId"];
                    data.IsActive = (bool)reader["IsActive"];
                    data.IsDeleted = (bool)reader["IsDeleted"];
                    data.IsBlocked = (bool)reader["IsBlocked"];
                    data.Password = (string)reader["Password"];
                    
                    break;
                }
                
            }
            connection.Close();
            return data;
        }

        public bool UpdateProfileByUserId(UsersModel data)
        {
            connection.Open();
            SqlCommand command = getSqlCommand("UpdateProfileByUserId");
           
            command.Parameters.AddWithValue("@UserId", 4);
            command.Parameters.AddWithValue("@FirstName", data.FirstName);
            command.Parameters.AddWithValue("@MiddleName", data.MiddleName);
            command.Parameters.AddWithValue("@LastName", data.LastName);
            command.Parameters.AddWithValue("@Gender", data.Gender);
            command.Parameters.AddWithValue("@AdharNo", data.AdharNo);
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