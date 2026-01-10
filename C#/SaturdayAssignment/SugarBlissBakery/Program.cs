class Program
{
    public Chocolate CalculateDiscountedPrice(Chocolate chocolate)
    {
        chocolate.TotalPrice = chocolate.Quantity * chocolate.PricePerUnit;
        double discountPercentage=0;
        if (chocolate.Flavour == "Dark")
            discountPercentage = 18;
        else if (chocolate.Flavour == "Milk")
            discountPercentage = 12;
        else if (chocolate.Flavour == "White")
            discountPercentage = 6;
        chocolate.DiscountedPrice = chocolate.TotalPrice - (chocolate.TotalPrice * discountPercentage / 100);
        return chocolate;


    }
    public static void Main(string[] args)
    {
        Chocolate chocolate = new Chocolate();
        Console.WriteLine("Enter the Flavour");
        chocolate.Flavour = Console.ReadLine();
        Console.WriteLine("Enter the quantity");
        chocolate.Quantity = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the price per unit");
        chocolate.PricePerUnit = Convert.ToInt32(Console.ReadLine());
        bool ans = chocolate.ValidateChocolateFlavour();
        if (ans == false)
        {
            Console.WriteLine("Invalid flavour");
            return;
        }
        else
        {
            Program p = new Program();
            chocolate = p.CalculateDiscountedPrice(chocolate);
            Console.WriteLine("Flavour : " + chocolate.Flavour);
            Console.WriteLine("Quantity : " + chocolate.Quantity);
            Console.WriteLine("Price Per Unit : " + chocolate.PricePerUnit);
            Console.WriteLine("Total Price : " + chocolate.TotalPrice);
            Console.WriteLine("Discounted Price : " + chocolate.DiscountedPrice);
        }
    }
}


