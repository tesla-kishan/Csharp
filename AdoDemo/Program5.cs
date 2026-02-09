// using System;
// using System.Data;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//             "Server=localhost,1433;" +
//             "Database=day15;" +          // use correct DB
//             "User Id=SA;" +
//             "Password=CodeWithArjun123;" +
//             "Encrypt=False;" +
//             "TrustServerCertificate=True;";

//         using (SqlConnection con = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 con.Open();

//                 SqlCommand cmd =
//                     new SqlCommand("SELECT dbo.FnSquare(@num)", con);

//                 cmd.CommandType = CommandType.Text;
//                 cmd.Parameters.AddWithValue("@num", 8);

//                 int result = Convert.ToInt32(cmd.ExecuteScalar());

//                 Console.WriteLine("Square value = " + result);
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("ERROR:");
//                 Console.WriteLine(ex.Message);
//             }
//         }

//         Console.ReadLine();
//     }
// }