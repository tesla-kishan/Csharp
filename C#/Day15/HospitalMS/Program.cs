

class Program
{
    // TASK 1 Method
    public static string GenerateDischargeSummary(string patientName)
    {
        return "Discharge summary generated for patient: " + patientName;
    }

    // TASK 2 Methods
    public static void SendSmsAlert(string message)
    {
        Console.WriteLine("SMS Alert: " + message);
    }

    public static void SendEmailAlert(string message)
    {
        Console.WriteLine("Email Alert: " + message);
    }

    public static void SendDashboardAlert(string message)
    {
        Console.WriteLine("Dashboard Alert: " + message);
    }

    static void Main()
    {
        // TASK 1
        ReportGenerator report = GenerateDischargeSummary;
        string summary = report("Rahul");
        Console.WriteLine(summary);

        // TASK 2
        HospitalAlert alert = SendSmsAlert;
        alert += SendEmailAlert;
        alert += SendDashboardAlert;
        alert("Emergency patient detected!");

        // TASK 3
        HospitalNotifier notifier = new HospitalNotifier();
        AdministrationDepartment admin = new AdministrationDepartment();
        notifier.PatientAdmitted += admin.Notify;
        notifier.AdmitPatient("Meera");

        // TASK 4
        Func<double, double, double> calculateBill = (consultation, tests) => consultation + tests;
        double total = calculateBill(600, 1800);
        Console.WriteLine("Total Bill Amount: " + total);

        // TASK 5
        Action<string> logAction = (message) => Console.WriteLine("[LOG] " + message);
        logAction("Billing process completed");

        // TASK 6
        Predicate<int> isSeniorCitizen = (age) => age >= 60;
        bool result = isSeniorCitizen(65);
        Console.WriteLine("Is Senior Citizen: " + result);
    }
}