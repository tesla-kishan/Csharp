// using System;
// using System.Data;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//             "Server=localhost,1433;" +
//             "Database=day15;" +
//             "User Id=SA;" +
//             "Password=CodeWithArjun123;" +
//             "Encrypt=False;" +
//             "TrustServerCertificate=True;";

//         using (SqlConnection con = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 Console.Write("Enter Name: ");
//                 string name = Console.ReadLine();

//                 Console.Write("Enter Age: ");
//                 int age = int.Parse(Console.ReadLine());

//                 con.Open();

//                 using (SqlCommand cmd =
//                     new SqlCommand("sp_InsertStudent", con))
//                 {
//                     cmd.CommandType = CommandType.StoredProcedure;

//                     cmd.Parameters.AddWithValue("@Name", name);
//                     cmd.Parameters.AddWithValue("@Age", age);

//                     int rows = cmd.ExecuteNonQuery();

//                     Console.WriteLine(
//                         $"\n{rows} row inserted successfully ");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("\nERROR:");
//                 Console.WriteLine(ex.Message);
//             }
//         }

//         Console.WriteLine("\nPress Enter to exit...");
//         Console.ReadLine();
//     }
// }