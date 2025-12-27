
public class ContractEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }

    public override double GetMonthlyPay()
    {
        double totalHours = 0;
        foreach (double h in WeeklyHours)
        {
            totalHours += h;
        }
        return totalHours * HourlyRate;
    }
}


























