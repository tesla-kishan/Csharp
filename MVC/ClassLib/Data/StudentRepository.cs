using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using global::MVCwithADO.Models;
using Microsoft.Extensions.Configuration;


namespace MVCwithADO.Data
{
    public class StudentRepository
    {
        private readonly string? _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=Lpu.db";
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqliteConnection con = new SqliteConnection(_connectionString))
            {
                string query = "SELECT Id, Name, Marks FROM Students";

                SqliteCommand cmd = new SqliteCommand(query, con);

                con.Open();
                SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)(long)reader["Id"],
                        Name = reader["Name"]?.ToString() ?? "",
                        Marks = (int)(long)reader["Marks"]
                    });
                }
            }

            return students;
        }
    }
}