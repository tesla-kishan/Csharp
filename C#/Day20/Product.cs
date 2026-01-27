using System.Collections.Generic;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }

    public int ModelYear { get; set; }
    public decimal ListPrice { get; set; }

    // Relationships
    public Brand Brand { get; set; }
    public Category Category { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public List<Stock> Stocks { get; set; }
}