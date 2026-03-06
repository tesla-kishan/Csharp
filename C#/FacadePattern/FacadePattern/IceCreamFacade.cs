using System;

namespace FacadePattern
{
    public class IceCreamFacade
    {
        private FlavorService flavorService;
        private ConeService coneService;
        private PaymentService paymentService;

        public IceCreamFacade()
        {
            flavorService = new FlavorService();
            coneService = new ConeService();
            paymentService = new PaymentService();
        }

        public string GetIceCream()
        {
            string flavor = flavorService.GetFlavor();
            string cone = coneService.GetCone();
            paymentService.ProcessPayment();

            return flavor + " in a " + cone;
        }
    }
}