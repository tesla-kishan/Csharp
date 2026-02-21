using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter Id:");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Enter Marks:");
            int marks = int.Parse(Console.ReadLine() ?? "0");

            string connectionString =
                "Server=localhost;" +     // Change if needed
                "Database=day15;" +
                "User Id=sa;" +
                "Password=CodeWithArjun123;" +
                "TrustServerCertificate=True;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                Console.WriteLine("Connecting to database...");
                con.Open();
                Console.WriteLine("Connected successfully!");

                string query = "INSERT INTO Student (Id, Name, Marks) VALUES (@Id, @Name, @Marks)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Marks", marks);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Inserted Successfully");
                    else
                        Console.WriteLine("Insertion Failed");
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Database Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("Press Enter to Exit...");
        Console.ReadLine();
    }
}