struct StockPrice
{
    public string StockSymbol;
    public double Price;

}

class Trade
{
    public int TradeID;
    public string StockSymbol;
    public int Quantity;
}

class Trade1 { }

class EquityTrade : Trade1 { }
