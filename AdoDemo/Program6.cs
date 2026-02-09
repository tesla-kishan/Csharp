using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program6   //  different class name
{
    static void Main()
    {
        string conStr =
            "Server=localhost,1433;" +
            "Database=day15;" +
            "User Id=SA;" +
            "Password=CodeWithArjun123;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        DataSet ds = new DataSet();

        try
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                Console.WriteLine("Connection successful!");

                // Command with Stored Procedure
                SqlCommand cmd =
                    new SqlCommand("sp_GetStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // DataAdapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Fill DataSet
                da.Fill(ds, "Students");
            }

            // Read from DataSet (DISCONNECTED)
            Console.WriteLine("\nStudents List:");

            foreach (DataRow row in ds.Tables["Students"].Rows)
            {
                Console.WriteLine(
                    $"{row["Id"]} {row["Name"]} {row["Age"]}");
            }
        }
        catch (SqlException ex)        // ✅ specific exception
        {
            Console.WriteLine("Database error:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)           // ✅ general exception
        {
            Console.WriteLine("Unexpected error:");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("\nProgram execution completed.");
        }

        Console.ReadLine();
    }
}