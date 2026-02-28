using System;
using Microsoft.Data.SqlClient;

public class Program
{
    public static void Main()
    {
        string connectionString = "Server=KishanPc\\SQLEXPRESS;Database=kishan;Trusted_Connection=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully.");

                string query = "SELECT TOP 10 * FROM Capgemini";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            "Id: " + reader["Id"] +
                            ", Name: " + reader["Name"] +
                            ", Marks: " + reader["Marks"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}