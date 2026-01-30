using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<dynamic> books = new List<dynamic>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n==== Library Management System ====");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            Console.WriteLine("3. Exit");
            Console.Write("Select option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AdminMenu();
                    break;
                case "2":
                    UserMenu();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    // ================= ADMIN =================
    static void AdminMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Admin Menu ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("5. Back");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    UpdateBook();
                    break;
                case "3":
                    DeleteBook();
                    break;
                case "4":
                    ViewBooks();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    static void AddBook()
    {
        dynamic book = new System.Dynamic.ExpandoObject();

        book.Id = nextId++;
        Console.Write("Book Name: ");
        book.Name = Console.ReadLine();

        Console.Write("Publisher: ");
        book.Publisher = Console.ReadLine();

        Console.Write("Price: ");
        book.Price = decimal.Parse(Console.ReadLine());

        books.Add(book);
        Console.WriteLine("✅ Book added successfully!");
    }

    static void UpdateBook()
    {
        Console.Write("Enter Book ID to update: ");
        int id = int.Parse(Console.ReadLine());

        dynamic book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            Console.WriteLine("❌ Book not found!");
            return;
        }

        Console.Write("New Name: ");
        book.Name = Console.ReadLine();

        Console.Write("New Publisher: ");
        book.Publisher = Console.ReadLine();

        Console.Write("New Price: ");
        book.Price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("✅ Book updated successfully!");
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        dynamic book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            Console.WriteLine("❌ Book not found!");
            return;
        }

        books.Remove(book);
        Console.WriteLine("✅ Book deleted successfully!");
    }

    static void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        Console.WriteLine("\nID | Name | Publisher | Price");
        foreach (var b in books)
        {
            Console.WriteLine($"{b.Id} | {b.Name} | {b.Publisher} | {b.Price}");
        }
    }

    // ================= USER =================
    static void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- User Menu ---");
            Console.WriteLine("1. Browse Books");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Search by Publisher");
            Console.WriteLine("4. Highest Price Book");
            Console.WriteLine("5. Lowest Price Book");
            Console.WriteLine("6. Back");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewBooks();
                    break;
                case "2":
                    SearchByName();
                    break;
                case "3":
                    SearchByPublisher();
                    break;
                case "4":
                    HighestPriceBook();
                    break;
                case "5":
                    LowestPriceBook();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    static void SearchByName()
    {
        Console.Write("Enter book name: ");
        string name = Console.ReadLine();

        var result = books.Where(b =>
            b.Name.ToString().Contains(name, StringComparison.OrdinalIgnoreCase));

        DisplayResult(result);
    }

    static void SearchByPublisher()
    {
        Console.Write("Enter publisher name: ");
        string publisher = Console.ReadLine();

        var result = books.Where(b =>
            b.Publisher.ToString().Contains(publisher, StringComparison.OrdinalIgnoreCase));

        DisplayResult(result);
    }

    static void HighestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        var book = books.OrderByDescending(b => b.Price).First();
        DisplayBook(book);
    }

    static void LowestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        var book = books.OrderBy(b => b.Price).First();
        DisplayBook(book);
    }

    // ================= HELPERS =================
    static void DisplayResult(IEnumerable<dynamic> result)
    {
        if (!result.Any())
        {
            Console.WriteLine("No matching books found.");
            return;
        }

        foreach (var b in result)
        {
            DisplayBook(b);
        }
    }

    static void DisplayBook(dynamic b)
    {
        Console.WriteLine($"ID: {b.Id}, Name: {b.Name}, Publisher: {b.Publisher}, Price: {b.Price}");
    }
}