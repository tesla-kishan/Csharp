using System;

class Library
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ItemID { get; set; }
        public abstract void DisplayItemDetails();
        public abstract int CalculateLateFee(int days);

        public interface IReservable
        {
            void ReserveItem();
        }
        public interface INotifiable
        {
            void SendNotification(string message);
        }
        public class Book : LibraryItem, IReservable, INotifiable
        {
            void IReservable.ReserveItem()
            {
                Console.WriteLine("Book Reserved Successfully");
            }
            void INotifiable.SendNotification(string message)
            {
                Console.WriteLine($"Notification Sent: {message}");
            }
            public override void DisplayItemDetails()
            {
                Console.WriteLine("Item Type: Book");
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Author: {Author}");
                Console.WriteLine($"Item ID: {ItemID}");
            }
            public override int CalculateLateFee(int days)
            {
                return days * 1;
            }
        }
        public class Magazine : LibraryItem
        {
            public override void DisplayItemDetails()
            {
                Console.WriteLine("Item Type: Magazine");
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Author: {Author}");
                Console.WriteLine($"Item ID: {ItemID}");
            }

            public override int CalculateLateFee(int days)
            {
                return days * 1; // assuming 1 for simplicity
            }
        }
        public class eBook : LibraryItem
        {
            public void Download()
            {
                Console.WriteLine("eBook downloaded successfully.");
            }

            public override void DisplayItemDetails()
            {
                Console.WriteLine("Item Type: eBook");
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Author: {Author}");
                Console.WriteLine($"Item ID: {ItemID}");
            }

            public override int CalculateLateFee(int days)
            {
                return 0;
            }
        }
    }

    public static class LibraryAnalytics
    {
        public static int TotalBorrowedItems { get; set; }
        public static void DisplayAnalytics()
        {
            Console.WriteLine($"Total Borrowed Items: {TotalBorrowedItems}");
        }
    }

    public enum UserRole
    {
        Admin,
        Member
    }

    public enum ItemStatus
    {
        Available,
        Borrowed,
        Reserved
    }
}