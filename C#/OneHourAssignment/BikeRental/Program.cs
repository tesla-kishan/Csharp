using System;
using System.Collections.Generic;

namespace BikeRentalApp
{
    public class Bike
    {
        public string Model{get; set;}
        public int PricePerDay{get; set;}
        public string Brand{get; set;}
    }
    public class BikeUtility
    {
        public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();
        public void AddBikeDetails(string model, string brand, int pricePerDay)
        {
            Bike bike = new Bike();
            bike.Model = model;
            bike.Brand = brand;
            bike.PricePerDay = pricePerDay;
            int key = bikeDetails.Count+1;
            bikeDetails.Add(key,bike);
        }
        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> result = new SortedDictionary<string, List<Bike>>();
            foreach(var item in bikeDetails)
            {
                Bike bike = item.Value;
                if (!result.ContainsKey(bike.Brand))
                {
                    result[bike.Brand]= new List<Bike>();
                }
                result[bike.Brand].Add(bike);
            }
            return result;
        }
    }
    class Program
{
    // public static SortedDictionary<int, Bike> bikeDetails = BikeUtility.bikeDetails;
    static void Main(string[] args)
    {
        BikeUtility utility = new BikeUtility();
        while (true)
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                Console.WriteLine("Enter the model:");
                string model = Console.ReadLine();
                Console.Write("Enter the brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter the price per day: ");
                int price = int.Parse(Console.ReadLine());
                utility.AddBikeDetails(model,brand,price);
                Console.WriteLine("Bike details added successfully");
                break;
                case 2:
                var grouped = utility.GroupBikesByBrand();
                foreach (var brandGroup in grouped)
                {
                    foreach(var bike in brandGroup.Value)
                    {
                        Console.WriteLine(brandGroup.Key +" " + bike.Model);
                    }
                }
                break;
                case 3:
                return;
            }
        }
    }
}

}

