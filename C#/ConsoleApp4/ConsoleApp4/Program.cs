using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create objects
            var orderService = new OrderService();
            var evaluationService = new GoldEvaluationService();
            var pricingService = new PricingService();
            var paymentService = new PaymentService();

            // Event chain (IMPORTANT)
            orderService.OrderPlaced += evaluationService.EvaluateGold;
            evaluationService.GoldEvaluated += pricingService.CalculatePrice;
            pricingService.PriceCalculated += paymentService.MakePayment;

            // Start flow
            orderService.PlaceOrder(5); // 5 grams
        }
    }

    // 1️⃣ Order Service
    public class OrderService
    {
        public event Action<int> OrderPlaced;

        public void PlaceOrder(int weight)
        {
            Console.WriteLine($"Order placed for {weight}g gold");

            OrderPlaced?.Invoke(weight);
        }
    }

    // 2️⃣ Gold Evaluation Service
    public class GoldEvaluationService
    {
        public event Action<int> GoldEvaluated;

        public void EvaluateGold(int weight)
        {
            Console.WriteLine($"Evaluating gold: {weight}g");

            // You can add purity logic here later

            GoldEvaluated?.Invoke(weight);
        }
    }

    // 3️⃣ Pricing Service
    public class PricingService
    {
        public event Action<double> PriceCalculated;

        private double pricePerGram = 6000;

        public void CalculatePrice(int weight)
        {
            double total = weight * pricePerGram;

            Console.WriteLine($"Price calculated: Rs.{total}");

            PriceCalculated?.Invoke(total);
        }
    }

    // 4️⃣ Payment Service
    public class PaymentService
    {
        public void MakePayment(double amount)
        {
           
            Console.WriteLine($"Payment of Rs.{amount} successful");
        }
    }
}