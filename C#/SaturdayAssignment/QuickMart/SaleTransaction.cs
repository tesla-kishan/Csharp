class SaleTransaction
{
    public string InvoiceNo { get; set; }
    public string CustomerName { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal SellingAmount { get; set; }
    public string ProfitOrLossStatus { get; set; }
    public decimal ProfitOrLossAmount { get; set; }
    public decimal ProfitMarginPercent { get; set; }
    public static SaleTransaction LastTransaction;
    public static bool HasLastTransaction = false;
    public static void CreateTransaction()
    {
        SaleTransaction tx = new SaleTransaction();

        Console.Write("Enter Invoice No: ");
        tx.InvoiceNo = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(tx.InvoiceNo))
        {
            Console.WriteLine("Invoice number cannot be empty.");
            return;
        }

        Console.Write("Enter Customer Name: ");
        tx.CustomerName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        tx.ItemName = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
        {
            Console.WriteLine("Quantity must be greater than zero.");
            return;
        }
        tx.Quantity = qty;

        Console.Write("Enter Purchase Amount (total): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal purchase) || purchase <= 0)
        {
            Console.WriteLine("Purchase amount must be greater than zero.");
            return;
        }
        tx.PurchaseAmount = purchase;

        Console.Write("Enter Selling Amount (total): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal selling) || selling < 0)
        {
            Console.WriteLine("Selling amount cannot be negative.");
            return;
        }
        tx.SellingAmount = selling;

        Calculate(tx);

        LastTransaction = tx;
        HasLastTransaction = true;

        Console.WriteLine("\nTransaction saved successfully.");
        PrintCalculation(tx);
    }

    public static void ViewLastTransaction()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        var t = LastTransaction;

        Console.WriteLine("\n-------------- Last Transaction --------------");
        Console.WriteLine($"InvoiceNo: {t.InvoiceNo}");
        Console.WriteLine($"Customer: {t.CustomerName}");
        Console.WriteLine($"Item: {t.ItemName}");
        Console.WriteLine($"Quantity: {t.Quantity}");
        Console.WriteLine($"Purchase Amount: {t.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {t.SellingAmount:F2}");
        Console.WriteLine($"Status: {t.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
        Console.WriteLine("--------------------------------------------");
    }

    public static void RecalculateAndPrint()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        Calculate(LastTransaction);
        PrintCalculation(LastTransaction);
    }


    private static void Calculate(SaleTransaction t)
    {
        if (t.SellingAmount > t.PurchaseAmount)
        {
            t.ProfitOrLossStatus = "PROFIT";
            t.ProfitOrLossAmount = t.SellingAmount - t.PurchaseAmount;
        }
        else if (t.SellingAmount < t.PurchaseAmount)
        {
            t.ProfitOrLossStatus = "LOSS";
            t.ProfitOrLossAmount = t.PurchaseAmount - t.SellingAmount;
        }
        else
        {
            t.ProfitOrLossStatus = "BREAK-EVEN";
            t.ProfitOrLossAmount = 0;
        }

        t.ProfitMarginPercent = (t.ProfitOrLossAmount / t.PurchaseAmount) * 100;
    }

    private static void PrintCalculation(SaleTransaction t)
    {
        Console.WriteLine($"Status: {t.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
        Console.WriteLine("------------------------------------------------------");
    }
}

