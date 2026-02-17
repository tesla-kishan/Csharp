using System;

class Program
{
    static void Main()
    {
        Book book = null;

        try
        {
            string[] input = Console.ReadLine().Split(' ');

            if (input.Length != 4)
                throw new Exception("Invalid input format");

            string id = input[0];
            string title = input[1];
            int price = int.Parse(input[2]);
            int stock = int.Parse(input[3]);

            book = new Book(id, title, price, stock);
        }
        catch (FormatException)
        {
            Console.WriteLine("Price and Stock must be numbers");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        BookUtility utility = new BookUtility(book);

        while (true)
        {
            Console.WriteLine("1 → Display book details");
            Console.WriteLine("2 → Update book price");
            Console.WriteLine("3 → Update book stock");
            Console.WriteLine("4 → Exit");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        Console.WriteLine("Enter new price:");
                        int newPrice = int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(newPrice);
                        break;

                    case 3:
                        Console.WriteLine("Enter new stock:");
                        int newStock = int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(newStock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
