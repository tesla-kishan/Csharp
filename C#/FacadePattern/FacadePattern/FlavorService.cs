using System;

namespace FacadePattern
{
    public class FlavorService
    {
        public string GetFlavor()
        {
            Console.WriteLine("Checking available flavors...");
            return "Vanilla Ice Cream";
        }
    }
}