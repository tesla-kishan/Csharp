// using System;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string conStr =
//         "Server=localhost,1433;Database=master;User Id=SA;Password=CodeWithArjun123;TrustServerCertificate=True;";

//         using (SqlConnection con = new SqlConnection(conStr))
//         {
//             con.Open();

//             SqlCommand cmd =
//                 new SqlCommand("SELECT 1", con);

//             var result = cmd.ExecuteScalar();

//             Console.WriteLine("Connected  Result: " + result);
//         }
//     }
// }


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



// using System;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static string conStr =
// "Server=localhost,1433;Database=day12;User Id=sa;Password=CodeWithArjun123;TrustServerCertificate=True;";

//     static void Main()
//     {
//         while (true)
//         {
//             Console.WriteLine("\n1.Insert  2.View  3.Update  4.Delete  5.Exit");
//             int ch = int.Parse(Console.ReadLine());

//             switch (ch)
//             {
//                 case 1: Insert(); break;
//                 case 2: View(); break;
//                 case 3: Update(); break;
//                 case 4: Delete(); break;
//                 case 5: return;
//             }
//         }
//     }

//     static void Insert()
//     {
//         Console.Write("Name: ");
//         string name = Console.ReadLine();

//         Console.Write("Age: ");
//         int age = int.Parse(Console.ReadLine());

//         using SqlConnection con = new SqlConnection(conStr);
//         con.Open();

//         SqlCommand cmd =
//             new SqlCommand("INSERT INTO Students(Name,Age) VALUES(@n,@a)", con);

//         cmd.Parameters.AddWithValue("@n", name);
//         cmd.Parameters.AddWithValue("@a", age);

//         cmd.ExecuteNonQuery();
//         Console.WriteLine("Inserted ✅");
//     }

//     static void View()
//     {
//         using SqlConnection con = new SqlConnection(conStr);
//         con.Open();

//         SqlCommand cmd =
//             new SqlCommand("SELECT * FROM Students", con);

//         SqlDataReader r = cmd.ExecuteReader();

//         while (r.Read())
//             Console.WriteLine($"{r["Id"]} {r["Name"]} {r["Age"]}");
//     }

//     static void Update()
//     {
//         Console.Write("Id: ");
//         int id = int.Parse(Console.ReadLine());

//         Console.Write("New Age: ");
//         int age = int.Parse(Console.ReadLine());

//         using SqlConnection con = new SqlConnection(conStr);
//         con.Open();

//         SqlCommand cmd =
//             new SqlCommand("UPDATE Students SET Age=@a WHERE Id=@i", con);

//         cmd.Parameters.AddWithValue("@a", age);
//         cmd.Parameters.AddWithValue("@i", id);

//         cmd.ExecuteNonQuery();
//         Console.WriteLine("Updated ✅");
//     }

//     static void Delete()
//     {
//         Console.Write("Id: ");
//         int id = int.Parse(Console.ReadLine());

//         using SqlConnection con = new SqlConnection(conStr);
//         con.Open();

//         SqlCommand cmd =
//             new SqlCommand("DELETE FROM Students WHERE Id=@i", con);

//         cmd.Parameters.AddWithValue("@i", id);

//         cmd.ExecuteNonQuery();
//         Console.WriteLine("Deleted ✅");
//     }
// }

