using Product_Category.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product_Category.Models
{
    public class Database
    {
        SqlConnection connection;
        public Products Products { get; set; }
        public Orders Orders { get; set; }
        public Database()
        {
            string connString = @"Server=DESKTOP-VIHR486\SQLEXPRESS; Database= ECOMMERCE; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connString);
            Products = new Products(connection);
            Orders = new Orders(connection);
        }

    }
}