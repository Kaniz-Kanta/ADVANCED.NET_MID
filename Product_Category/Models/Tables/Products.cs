using Product_Category.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product_Category.Models.Tables
{
    public class Products
    {
        SqlConnection connection;
        public Products(SqlConnection connection)
        {
            this.connection = connection;
        }
        public void AddProduct( Product p)
        {
            connection.Open();
            string query = "INSERT INTO Products (ProductName,Quantity, Price, Description) VALUES ('" + p.ProductName + "','" + p.Quantity + "','" + p.Price + "','"+p.Description+"')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int r = cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<Product> GetAllProduct()
        {
            connection.Open();
            string query = "SELECT * FROM Products";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    Quantity = reader.GetString(reader.GetOrdinal("Quantity")),
                    Price = reader.GetString(reader.GetOrdinal("Price")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                products.Add(product);
            }
            connection.Close();
            return products;
        }
        public Product GetProductById(int id)
        {
            connection.Open();
            string query = "SELECT * FROM Products WHERE Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Product p = null;
            while (reader.Read())
            {
                p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    Quantity = reader.GetString(reader.GetOrdinal("Quantity")),
                    Price = reader.GetString(reader.GetOrdinal("Price")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
            }
            connection.Close();
            return p;
        }
        public void UpdateProduct(Product p)
        {
            connection.Open();
            string query = "UPDATE Products SET ProductName='"+p.ProductName+"',Quantity='"+p.Quantity+"', Price='"+p.Price+"', Description='"+p.Description+"' WHERE Id='"+p.Id+"'";
            SqlCommand cmd = new SqlCommand(query, connection);
            int r = cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteProduct(int id)
        {
            connection.Open();
            string query = "DELETE FROM Products WHERE Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            int r = cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}