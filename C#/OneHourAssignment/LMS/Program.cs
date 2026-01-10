using System;
using System.Collections.Generic;
using ItemsAlias = Library.LibraryItem;
using IReservable = Library.LibraryItem.IReservable;
using INotifiable = Library.LibraryItem.INotifiable;
using Users = LMS;

class Program
{
    static void Main()
    {
        // ===================== TASK 1 PROOF =====================
        var book = new ItemsAlias.Book
        {
            Title = "C# Fundamentals",
            Author = "John Doe",
            ItemID = 101
        };

        var magazine = new ItemsAlias.Magazine
        {
            Title = "Tech Today",
            Author = "Jane Doe",
            ItemID = 201
        };

        book.DisplayItemDetails();
        Console.WriteLine($"Late Fee for 3 days: {book.CalculateLateFee(3)}\n");

        magazine.DisplayItemDetails();
        Console.WriteLine($"Late Fee for 3 days: {magazine.CalculateLateFee(3)}\n");

        // ===================== TASK 2 & 4 PROOF =====================
        IReservable reservable = book;
        reservable.ReserveItem();

        INotifiable notifiable = book;
        notifiable.SendNotification("Your reserved book is ready for pickup.");

        Console.WriteLine();

        // ===================== TASK 3: POLYMORPHISM =====================
        List<Library.LibraryItem> items = new List<Library.LibraryItem>
        {
            book,
            magazine
        };

        foreach (var item in items)
        {
            item.DisplayItemDetails();
            Console.WriteLine();
        }

        Console.WriteLine("Explanation: Method selection happens at runtime.\n");

        // ===================== TASK 6 PROOF =====================
        Library.LibraryAnalytics.TotalBorrowedItems += 5;
        Library.LibraryAnalytics.DisplayAnalytics();

        Console.WriteLine();

        // ===================== TASK 7 PROOF =====================
        var user = new Users.Member
        {
            Name = "Kishan",
            Role = Library.UserRole.Member
        };

        Library.ItemStatus status = Library.ItemStatus.Borrowed;

        Console.WriteLine($"User Role: {user.Role}");
        Console.WriteLine($"Item Status: {status}");
        Console.WriteLine("Enums prevent invalid values and improve readability.\n");

        // ===================== BONUS TASK =====================
        Console.WriteLine("Admin Alert: System maintenance scheduled.");
        Console.WriteLine("Member Notification: Your borrowed item is due tomorrow.");

        var ebook = new ItemsAlias.eBook
        {
            Title = "Digital C# Guide",
            Author = "Tech Author",
            ItemID = 301
        };

        ebook.Download();
    }
}