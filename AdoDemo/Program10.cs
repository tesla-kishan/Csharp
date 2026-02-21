// using System;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         // SQL Server connection string using IP address
        // string connectionString =
        //     "Server=10.20.93.182,1433;" +
        //     "Database=day15;" +
        //     "User Id=sa;" +
        //     "Password=CodeWithArjun123;" +
        //     "TrustServerCertificate=True;";

//         try
//         {
//             using (SqlConnection connection = new SqlConnection(connectionString))
//             {
//                 connection.Open();
//                 Console.WriteLine("✅ Connection Successful!");

//                 string query = "SELECT @@VERSION";

//                 using (SqlCommand command = new SqlCommand(query, connection))
//                 {
//                     SqlDataReader reader = command.ExecuteReader();

//                     while (reader.Read())
//                     {
//                         Console.WriteLine("\nSQL Server Version:");
//                         Console.WriteLine(reader[0]);
//                     }
//                 }
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("❌ Error occurred:");
//             Console.WriteLine(ex.Message);
//         }
//     }
// }