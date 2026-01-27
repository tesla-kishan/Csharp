using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a customer
        Customer customer = new Customer
        {
            CustomerId = 1,
            FirstName = "Kishan",
            LastName = "Lal",
            Email = "kishan@mail.com"
        };

        // Create a store
        Store store = new Store
        {
            StoreId = 101,
            StoreName = "Bike Store Delhi"
        };

        // Create staff
        Staff staff = new Staff
        {
            StaffId = 501,
            FirstName = "Rahul",
            Store = store
        };

        // Create an order
        Order order = new Order
        {
            OrderId = 9001,
            Customer = customer,
            Store = store,
            Staff = staff,
            OrderDate = DateTime.Now
        };

        // Print output
        Console.WriteLine("Order Created Successfully!");
        Console.WriteLine($"Customer: {order.Customer.FirstName}");
        Console.WriteLine($"Store: {order.Store.StoreName}");
        Console.WriteLine($"Staff: {order.Staff.FirstName}");
        Console.WriteLine($"Order Date: {order.OrderDate}");
    }
}