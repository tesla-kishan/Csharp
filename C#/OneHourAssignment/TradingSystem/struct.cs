struct PriceSnapshot
{
    public string? StockSymbol;
    public double StockPrice;

}

abstract class Trade
{
    public int TradeID{get;set;}
    public string StockSymbol{get;set;}
    public int Quantity{get;set;}
    public abstract double CalculateTradeValue();
    public override string ToString()
    {
        return $"TradeID : {TradeID} , StockSymbol : {StockSymbol} , Quantity : {Quantity}";
    }

}

class EquityTrade: Trade
{
    public double? MarketPrice{get;set;}
    public override double CalculateTradeValue()
    {
        return (MarketPrice ?? 0)*Quantity;
    }
}



class TradeRepository<T> where T : Trade
{
    public List<T> trades = new List<T>();
    public void AddTrade(T Trade)
    {
        trades.Add(Trade);
        TradeAnalytics.TotalTrades++;
        Console.WriteLine("Trade Added Successfully");
    }
    public List<T> GetAllTrades()
    {
        return trades;
    }
}
static class TradeAnalytics
{
    public static int TotalTrades=0;
    public static void DisplayAnalytics()
    {
        Console.WriteLine($"Total Trades Executed: {TotalTrades}");
    }
}

namespace TradingSystem
{
static class FinancialExtension
{
    public static double BrokerageCalculation(this double tradeValue)
    {
        return tradeValue*0.001;
    }
    public static double CalculateGST(this double brokerage)
    {
        return brokerage*0.18;
    }
}
}

static class TradeProcessor
{
    public static void ProcessTrade(Trade trade)
    {
        switch (trade)
        {
            case EquityTrade equityTrade:
                Console.WriteLine("Processing Equity Trade");
                break;

            default:
                Console.WriteLine("Unknown Trade Type");
                break;
        }
    }
}

