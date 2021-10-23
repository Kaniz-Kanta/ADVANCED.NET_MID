using Lecture3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture3.Models.Tables
{
    public class Courses
    {
        SqlConnection connection;
        public Courses(SqlConnection connection)
        {
            this.connection = connection;
        }
        public void Add(Course c)
        {
            connection.Open();
            string query = "INSERT INTO Courses (Name,Code) VALUES ('" + c.Name + "','"+c.Code+"')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int r = cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<Course> GetAllCourse()
        {
            return null;
        }
    }
}