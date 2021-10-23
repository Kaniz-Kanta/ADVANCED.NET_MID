using Lecture3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture3.Models.Tables
{
    public class Departments
    {
        SqlConnection connection;
        public Departments(SqlConnection connection)
        {
            this.connection = connection;
        }
        public void Add(Department d)
        {
            connection.Open();
            string query = "INSERT INTO Departments (Name) VALUES ('" + d.Name + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int r = cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<Department> GetAllDept()
        {
            return null;
        }
    }
}