using Product_Category.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product_Category.Models.Tables
{
    public class Orders
    {
        SqlConnection connection;
        public Orders(SqlConnection connection)
        {
            this.connection = connection;
        }
        public void AddOrder(string date, string time, string p_name)
        {
            connection.Open();
            string query = "INSERT INTO Orders (OrderDate, OrderTime,P_Name) VALUES ('" + date + "','" + time + "','" + p_name + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int r = cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}