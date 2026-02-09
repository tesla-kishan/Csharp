// using System;
// using System.Data;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string conStr =
//             "Server=localhost,1433;" +
//             "Database=day15;" +
//             "User Id=SA;" +
//             "Password=CodeWithArjun123;" +
//             "Encrypt=False;" +
//             "TrustServerCertificate=True;";

//         using (SqlConnection con = new SqlConnection(conStr))
//         {
//             try
//             {
//                 con.Open();

//                 //  GET HOSTEL STUDENT COUNT (ExecuteScalar)
//                 SqlCommand countCmd =
//                     new SqlCommand("sp_GetHostelStudentCount", con);
//                 countCmd.CommandType = CommandType.StoredProcedure;

//                 int hostelCount = (int)countCmd.ExecuteScalar();

//                 Console.WriteLine($"Hostel Students Count = {hostelCount}");

//                 //  IF COUNT > 5 → DELETE (ExecuteNonQuery)
//                 if (hostelCount > 5)
//                 {
//                     Console.Write("Enter category to delete (e.g. General): ");
//                     string category = Console.ReadLine();

//                     SqlCommand delCmd =
//                         new SqlCommand("sp_DeleteHostelStudentsByCategory", con);
//                     delCmd.CommandType = CommandType.StoredProcedure;
//                     delCmd.Parameters.AddWithValue("@Category", category);

//                     int rows = delCmd.ExecuteNonQuery();

//                     Console.WriteLine($"{rows} hostel student(s) deleted ");
//                 }
//                 // ELSE → SHOW ALL RECORDS (ExecuteReader)
//                 else
//                 {
//                     SqlCommand viewCmd =
//                         new SqlCommand("sp_ViewAllStudents", con);
//                     viewCmd.CommandType = CommandType.StoredProcedure;

//                     SqlDataReader dr = viewCmd.ExecuteReader();

//                     Console.WriteLine("\nAll Students:");
//                     while (dr.Read())
//                     {
//                         Console.WriteLine(
//                             $"{dr["Id"]} {dr["Name"]} {dr["Age"]} {dr["Category"]} Hostel:{dr["IsHostel"]}");
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

