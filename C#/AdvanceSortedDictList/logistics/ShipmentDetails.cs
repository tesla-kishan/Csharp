using System;

namespace LogisticsPro
{
    public class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode()
        {
            if (ShipmentCode == null)
                return false;

            if (ShipmentCode.Length != 7)
                return false;

            if (!ShipmentCode.StartsWith("GC#"))
                return false;

            string numericPart = ShipmentCode.Substring(3);

            foreach (char c in numericPart)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        public double CalculateTotalCost()
        {
            double ratePerKg = 0;

            switch (TransportMode)
            {
                case "Sea":
                    ratePerKg = 15.00;
                    break;

                case "Air":
                    ratePerKg = 50.00;
                    break;

                case "Land":
                    ratePerKg = 25.00;
                    break;

                default:
                    throw new Exception("Invalid transport mode");
            }

            double totalCost = (Weight * ratePerKg) + Math.Sqrt(StorageDays);

            return Math.Round(totalCost, 2);
        }
    }
}
