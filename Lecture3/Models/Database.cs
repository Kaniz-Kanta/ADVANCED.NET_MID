using Lecture3.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture3.Models
{
    public class Database
    {
        SqlConnection connection;
        public Courses Courses { get; set; }
        public Departments Departments { get; set; }
        public Students Students { get; set; }
        public Database()
        {
            string connString = @"Server=DESKTOP-VIHR486\SQLEXPRESS; Database= UMS; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connString);
            Courses = new Courses(connection);
            Students = new Students(connection);
            Departments = new Departments(connection);
        }
        
    }
}