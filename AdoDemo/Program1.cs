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

//                 Console.Write("Enter Department: ");
//                 string dept = (Console.ReadLine() ?? "").Trim();

//                 con.Open();
//                 Console.WriteLine("\nCONNECTED SUCCESSFULLY\n");

//                 using (SqlCommand cmd = new SqlCommand("sp_getStdByGenderDept", con))
//                 {
//                     cmd.CommandType = CommandType.StoredProcedure;
//                     cmd.Parameters.AddWithValue("@Gender", gender);
//                     cmd.Parameters.AddWithValue("@Dept", dept);

//                     using (SqlDataReader reader = cmd.ExecuteReader())
//                     {
//                         Console.WriteLine("Student Data");
//                         Console.WriteLine("---------------------");

//                         bool found = false;

//                         while (reader.Read())
//                         {
//                             found = true;
//                             Console.WriteLine(
//                                 $"Name: {reader["StdName"]}, " +
//                                 $"Dept: {reader["Dept"]}, " +
//                                 $"Gender: {reader["Gender"]}");
//                         }

//                         if (!found)
//                         {
//                             Console.WriteLine("No records found ❌");
//                         }
//                     }
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