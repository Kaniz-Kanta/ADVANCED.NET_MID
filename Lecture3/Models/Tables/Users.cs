using Lecture3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture3.Models.Tables
{
    public class Users
    {
        SqlConnection connection;
        public Users(SqlConnection connection)
        {
            this.connection = connection;
        }
        public User Authentication(string name, string password)
        {
            connection.Open();
            string query = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            User user = null;
            while (reader.Read())
            {
                user = new User()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    Password = reader.GetString(reader.GetOrdinal("Password"))
                };
            }
            connection.Close();
            return user;
        }
        public int GetType(string Username)
        {
            int Type = 0;
            connection.Open();
            string query = "SELECT * FROM Users WHERE Username='"+Username+"'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            User user = null;
            while (reader.Read())
            {
                user = new User()
                {
                    Type = reader.GetInt32(reader.GetOrdinal("Type"))
                };
            }
            connection.Close();
            return Type;
        }
    }
}