// using System;
// using Microsoft.Data.SqlClient;   
// using System.Diagnostics;

// namespace AdoNetPerformanceTest
// {
//     class Program8   
//     {
//         static void Main()
//         {
//             string cs =
//                 "Server=localhost,1433;" +
//                 "Database=day15;" +
//                 "User Id=SA;" +
//                 "Password=CodeWithArjun123;" +
//                 "Encrypt=False;" +
//                 "TrustServerCertificate=True;" +
//                 "Pooling=false;";

//             Stopwatch sw = Stopwatch.StartNew();

//             for (int i = 0; i < 100; i++)
//             {
//                 using (SqlConnection con = new SqlConnection(cs))
//                 {
//                     con.Open();

//                     SqlCommand cmd =
//                         new SqlCommand(
//                             "SELECT COUNT(*) FROM HostelStudents", con);

//                     cmd.ExecuteScalar();
//                 }
//             }

//             sw.Stop();

//             Console.WriteLine("Time taken (ms): " + sw.ElapsedMilliseconds);
//             Console.ReadLine();
//         }
//     }
// }