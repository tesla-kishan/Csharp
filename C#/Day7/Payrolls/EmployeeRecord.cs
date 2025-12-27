public abstract class EmployeeRecord
{
    public string EmployeeName{get;set;}
    public double[] WeeklyHours;
    public abstract double GetMonthlyPay();
}