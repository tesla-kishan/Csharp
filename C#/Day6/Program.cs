class Program
{
    public static void Main(String [] args)
    {
        // StockPrice OriginalPrice = new StockPrice
        // {
        //     StockSymbol="AABC",
        //     Price = 100.00
        // };
        // StockPrice CopiedPrice = OriginalPrice;
        // CopiedPrice.Price = 155.00;


        // Trade trade1 = new Trade
        // {
        //   TradeID = 101,
        //   StockSymbol = "AAPL",
        //   Quantity = 100  
        // };

        // Trade trade2 = trade1;
        // trade2.Quantity = 200;

        // Console.WriteLine(OriginalPrice.Price);
        // Console.WriteLine(CopiedPrice.Price);

        // Console.WriteLine(trade1.Quantity);
        // Console.WriteLine(trade2.Quantity);


        // Portfolio p1 = new Portfolio { Name = "Growth" };
        // Portfolio p2 = new Portfolio { Name = "Growth" };

        // Console.WriteLine(p1.Equals(p2));
        // Console.WriteLine(p1==p2);

        // Console.WriteLine(p1.GetHashCode());
        // Console.WriteLine(p2.GetHashCode());

        // Trade1 t = new EquityTrade();
        // Console.WriteLine(t.GetType());

        Repository<Customer> obj1 = new Repository<Customer>();
        obj1.Data = new Customer {Name = "Kishan"};
        Console.WriteLine(obj1.Data.Name);


        Calculator calc = new Calculator();
        int result = calc.Calculate(10,20);
        Console.WriteLine(calc.Calculate(10.1,20));
        Console.WriteLine(result);
        Double result2 = calc.Calculate(10.30,40.67);
        Console.WriteLine(result2);
    }
}