namespace TradingSystem
{
class Program
{
    static void Main()
    {
        // TASK 1: Price Snapshot
        PriceSnapshot snapshot = new PriceSnapshot
        {
            StockSymbol = "AAPL",
            StockPrice = 150.50
        };

        Console.WriteLine($"Stock Symbol: {snapshot.StockSymbol}");
        Console.WriteLine($"Stock Price: {snapshot.StockPrice}");

        // Repository
        TradeRepository<EquityTrade> repository = new TradeRepository<EquityTrade>();

        // TASK 3: Equity Trades
        EquityTrade trade1 = new EquityTrade
        {
            TradeID = 1,
            StockSymbol = "AAPL",
            Quantity = 100,
            MarketPrice = 150.5
        };

        EquityTrade trade2 = new EquityTrade
        {
            TradeID = 2,
            StockSymbol = "MSFT",
            Quantity = 50,
            MarketPrice = null
        };

        // TASK 4: Add trades
        repository.AddTrade(trade1);
        repository.AddTrade(trade2);

        // TASK 7 + 6: Process trades
        foreach (var trade in repository.GetAllTrades())
        {
            TradeProcessor.ProcessTrade(trade);

            double tradeValue = trade.CalculateTradeValue();
            double brokerage = tradeValue.BrokerageCalculation();
            double gst = brokerage.CalculateGST();

            Console.WriteLine($"Trade Value: {tradeValue}");
            Console.WriteLine($"Brokerage: {brokerage}");
            Console.WriteLine($"GST: {gst}");
            Console.WriteLine(trade);
            Console.WriteLine();
        }

        // TASK 5: Analytics
        TradeAnalytics.DisplayAnalytics();

        // TASK 8: Boxing & Unboxing
        object boxedTradeCount = TradeAnalytics.TotalTrades;
        Console.WriteLine($"Boxed Trade Count: {boxedTradeCount}");

        int unboxedTradeCount = (int)boxedTradeCount;
        Console.WriteLine($"Unboxed Trade Count: {unboxedTradeCount}");
    }
}
}