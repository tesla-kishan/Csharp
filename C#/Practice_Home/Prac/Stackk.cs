// using System;
// using System.Collections.Generic;

// public class Order
// {
//     public int OrderId{get;set;}
//     public string CustomerName{get;set;}
//     public string Item { get; set; }
//     public Stack<Order> AddOrderDetails(int orderId, string customerName, string item)
//     {
//         Order FreshOrder = new Order ();
//         FreshOrder.OrderId = orderId;
//         FreshOrder.CustomerName = customerName;
//         FreshOrder.Item = item;

//         Stackk.st.Push(FreshOrder);
//         return Stackk.st;
//     }
//     public string GetOrderDetails()
//     {
//         Order topOrder = Stackk.st.Peek();
//         return topOrder.OrderId + " " + topOrder.CustomerName + " " + topOrder.Item;
//     }
//     public Stack<Order> RemoveOrderDetails()
//     {
//         Stackk.st.Pop();
//         return Stackk.st;
//     }
// }

// public class Stackk
// {
//     public static Stack<Order> st = new Stack<Order>();
//     static void Main(string[] args)
//     {
//         int orderId = int.Parse(Console.ReadLine());
//         string customerName = Console.ReadLine();
//         string item = Console.ReadLine();

//         Order order = new Order();

//         order.AddOrderDetails(orderId, customerName, item);

//         Console.WriteLine(order.GetOrderDetails());

//         order.RemoveOrderDetails();       
//     }
// }