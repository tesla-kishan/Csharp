using System.Collections.Generic;

public class Store
{
    public int StoreId { get; set; }
    public string StoreName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public List<Staff> Staffs { get; set; }
    public List<Order> Orders { get; set; }
    public List<Stock> Stocks { get; set; }
}