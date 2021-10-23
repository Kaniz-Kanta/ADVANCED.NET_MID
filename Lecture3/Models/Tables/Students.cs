using Lecture3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture3.Models.Tables
{
    public class Students
    {
        SqlConnection connection;
        public Students(SqlConnection connection)
        {
            this.connection = connection;
        }
        public void AddStudent(Student s)
        {
            connection.Open();
            string query = "INSERT INTO Students (Name, Dob, Gender) VALUES ('" + s.Name + "','" + s.Dob + "','" + s.Gender + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int r = cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<Student> GetAllStudent()
        {
            connection.Open();
            string query = "SELECT * FROM Students";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender"))
                };
                students.Add(student);
            }
            connection.Close();
            return students;
        }
        public Student GetStudentById(int id)
        {
            connection.Open();
            string query = "SELECT * FROM Students WHERE Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Student s=null;
            while (reader.Read())
            {
                s = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender"))
                };
            }
            connection.Close();
            return s;
        }
    }
}