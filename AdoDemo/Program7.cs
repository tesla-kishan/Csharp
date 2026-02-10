// using System;
// using System.Data;

// class Program
// {
//     static void Main()
//     {
//         // 1. Create DataSet
//         DataSet ds = new DataSet();

//         // 2. Create DataTable
//         DataTable dt = new DataTable("Students");

//         // 3. Add Columns
//         dt.Columns.Add("Id", typeof(int));
//         dt.Columns.Add("Name", typeof(string));
//         dt.Columns.Add("Department", typeof(string));

//         // 4. Add Rows (Hard-coded data)
//         dt.Rows.Add(1, "Mahima", "IT");
//         dt.Rows.Add(2, "Harshith", "MCA");
//         dt.Rows.Add(3, "Ritik", "ECE");

//         // 5. Read DataTable
//         Console.WriteLine("Student Details:");
//         foreach (DataRow row in dt.Rows)
//         {
//             Console.WriteLine(
//                 $"{row["Id"]} - {row["Name"]} - {row["Department"]}"
//             );
//         }

//         // 6. Add DataTable to DataSet
//         ds.Tables.Add(dt);

//         // 7. Print number of tables in DataSet
//         Console.WriteLine("Total Tables in DataSet: " + ds.Tables.Count);

//         Console.ReadLine();
//     }
// }