public class OrderItem
{
    public int OrderId { get; set; }
    public int ItemId { get; set; }   // Composite Key Part
    public int ProductId { get; set; }

    public int Quantity { get; set; }
    public decimal ListPrice { get; set; }
    public decimal Discount { get; set; }

    // Relationships
    public Order Order { get; set; }
    public Product Product { get; set; }
}