using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            @"Server=KishanPc\SQLEXPRESS;Database=kishan;Trusted_Connection=True;TrustServerCertificate=True;";

        int senderId = 1;
        int receiverId = 2;
        decimal amount = 1000;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            // Begin Transaction
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // Query 1: Deduct amount from sender
                SqlCommand deductCmd = new SqlCommand(
                    "UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountId = @SenderId",
                    con,
                    transaction);

                deductCmd.Parameters.AddWithValue("@Amount", amount);
                deductCmd.Parameters.AddWithValue("@SenderId", senderId);

                deductCmd.ExecuteNonQuery();

                // Query 2: Add amount to receiver
                SqlCommand addCmd = new SqlCommand(
                    "UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountId = @ReceiverId",
                    con,
                    transaction);

                addCmd.Parameters.AddWithValue("@Amount", amount);
                addCmd.Parameters.AddWithValue("@ReceiverId", receiverId);

                addCmd.ExecuteNonQuery();

                // If both queries succeed → Commit
                transaction.Commit();

                Console.WriteLine("Transaction Completed Successfully");
            }
            catch (Exception ex)
            {
                // If any query fails → Rollback
                transaction.Rollback();

                Console.WriteLine("Transaction Failed. Amount Reversed.");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        Console.WriteLine("Press Enter to Exit...");
        Console.ReadLine();
    }
}