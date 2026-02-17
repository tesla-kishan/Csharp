using System;

namespace LogisticsPro
{
    class Program
    {
        static void Main(string[] args)
        {
            ShipmentDetails shipment = new ShipmentDetails();

            Console.WriteLine("Enter Shipment Code:");
            shipment.ShipmentCode = Console.ReadLine();

            if (!shipment.ValidateShipmentCode())
            {
                Console.WriteLine("Invalid shipment code");
                return;
            }

            Console.WriteLine("Enter Transport Mode:");
            shipment.TransportMode = Console.ReadLine();

            Console.WriteLine("Enter Weight:");
            shipment.Weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Storage Days:");
            shipment.StorageDays = Convert.ToInt32(Console.ReadLine());

            double totalCost = shipment.CalculateTotalCost();

            Console.WriteLine($"The total shipping cost is {totalCost:F2}");
        }
    }
}
//sample input 
// GC#1001
// Air
// 10
// 16