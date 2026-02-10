// using System;
// using System.Data;
// using Microsoft.Data.SqlClient;  

// class Program9   
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

//         DataSet ds = new DataSet();

//         try
//         {
//             using (SqlConnection con = new SqlConnection(connectionString))
//             {
//                 con.Open();
//                 Console.WriteLine("Connection successful!");

//                 SqlDataAdapter da =
//                     new SqlDataAdapter("sp_GetStudentss", con);
//                 da.SelectCommand.CommandType =
//                     CommandType.StoredProcedure;

//                 // 🔑 Auto-generate INSERT/UPDATE/DELETE
//                 SqlCommandBuilder cb = new SqlCommandBuilder(da);

//                 // READ
//                 da.Fill(ds, "Studentss");
//                 DataTable dt = ds.Tables["Studentss"];

//                 // CREATE
//                 DataRow newRow = dt.NewRow();
//                 newRow["Name"] = "Arun";
//                 newRow["Department"] = "IT";
//                 dt.Rows.Add(newRow);

//                 // UPDATE
//                 if (dt.Rows.Count > 0)
//                     dt.Rows[0]["Department"] = "CSE";

//                 // DELETE
//                 if (dt.Rows.Count > 1)
//                     dt.Rows[1].Delete();

//                 // 🔑 Push changes to DB
//                 da.Update(dt);
//             }

//             Console.WriteLine("CRUD operations completed successfully ");
//         }
//         catch (SqlException ex)
//         {
//             Console.WriteLine("Database error:");
//             Console.WriteLine(ex.Message);
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("Unexpected error:");
//             Console.WriteLine(ex.Message);
//         }

//         Console.ReadLine();
//     }
// }

