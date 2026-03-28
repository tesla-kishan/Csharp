namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; } = "Pending";
    }
}