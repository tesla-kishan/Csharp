delegate void PaymentDelegate(decimal amount);
class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Payment of " + amount + " Processed Successfully.");   
    }

}

static class PaymentExtension
{
    public static bool isValidPayment(this decimal amount)
    {
        return amount>0 && amount<=1000000;
    }
}