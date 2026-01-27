public class Stock
{
    public int StoreId { get; set; }
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    // Relationships
    public Store Store { get; set; }
    public Product Product { get; set; }
}