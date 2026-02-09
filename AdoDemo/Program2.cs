// using System;
// using System.Data;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//             "Server=localhost,1433;" +
//             "Database=Ado;" +
//             "User Id=SA;" +
//             "Password=CodeWithArjun123;" +
//             "Encrypt=False;" +
//             "TrustServerCertificate=True;";

//         using (SqlConnection con = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 Console.Write("Enter Gender (M/F): ");
//                 string gender = (Console.ReadLine() ?? "").Trim().ToUpper();

//                 con.Open();

//                 using (SqlCommand cmd =
//                     new SqlCommand("sp_getStudentCountByGender", con))
//                 {
//                     cmd.CommandType = CommandType.StoredProcedure;
//                     cmd.Parameters.AddWithValue("@Gender", gender);

//                     int count = (int)cmd.ExecuteScalar();

//                     Console.WriteLine(
//                         $"\nTotal students with gender '{gender}' = {count}");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("ERROR:");
//                 Console.WriteLine(ex.Message);
//             }
//         }

//         Console.WriteLine("\nPress Enter to exit...");
//         Console.ReadLine();
//     }
// }