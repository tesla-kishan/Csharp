using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString =
        @"Server=KishanPc\SQLEXPRESS;Database=kishan;Trusted_Connection=True;TrustServerCertificate=True;";

    static void Main()
    {
        Console.WriteLine("Enter Department:");
        string dept = Console.ReadLine() ?? "";

        GetEmployeesByDepartment(dept);
        GetDepartmentCount(dept);
        GetEmployeeOrders();
        GetDuplicateEmployees();

        Console.WriteLine("\nPress Enter to Exit...");
        Console.ReadLine();
    }

    static void GetEmployeesByDepartment(string department)
    {
        using SqlConnection con = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Department", department);

        con.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\n--- Employees ---");

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["EmpId"]} | {reader["Name"]} | {reader["Department"]}"
            );
        }
    }

    static void GetDepartmentCount(string department)
    {
        using SqlConnection con = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetDepartmentEmployeeCount", con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Department", department);

        SqlParameter outputParam = new SqlParameter("@TotalEmployees", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        cmd.Parameters.Add(outputParam);

        con.Open();
        cmd.ExecuteNonQuery();

        int total = (int)(cmd.Parameters["@TotalEmployees"].Value ?? 0);

        Console.WriteLine($"\nTotal employees in {department}: {total}");
    }

    static void GetEmployeeOrders()
    {
        using SqlConnection con = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetEmployeeOrders", con);

        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\n--- Employee Orders ---");

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["Name"]} | {reader["OrderId"]} | {reader["OrderAmount"]}"
            );
        }
    }

    static void GetDuplicateEmployees()
    {
        using SqlConnection con = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetDuplicateEmployees", con);

        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\n--- Duplicate Employees ---");
        
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["EmpId"]} | {reader["Phone"]} | {reader["Email"]}"
            );
        }
    }
}