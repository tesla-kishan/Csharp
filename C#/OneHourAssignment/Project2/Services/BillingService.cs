namespace Project2.Services;
class BillingService
{
    public double ConsultationFee;
    public double TestCharges;
    public double RoomCharges;
    public double CalculateTotal()
    {
        return ConsultationFee+TestCharges+RoomCharges;
    }
    public double CalculateTotal(double discount)
    {
        return CalculateTotal()-discount;
    }
}