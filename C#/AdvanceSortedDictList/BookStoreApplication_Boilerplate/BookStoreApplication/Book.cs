using System;

public class Book
{
    public string Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }

    public Book(string id, string title, int price, int stock)
    {
        Id = id;
        Title = title;
        Price = price;
        Stock = stock;
    }
}
