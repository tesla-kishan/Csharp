using System;

namespace FacadePattern
{
    public class ConeService
    {
        public string GetCone()
        {
            Console.WriteLine("Preparing cone...");
            return "Cone";
        }
    }
}