using System;
using Project2.Core;
using Project2.Services;
using Project2.Utilities;

partial class Program
{
    static void Main()
    {
        Console.WriteLine("Hospital Name: " + HospitalConfig.HospitalName);

        Patient patient = new Patient(1, "Kishan", 24);
        patient.SetMedicalHistory("No allergies");

        Doctor doctor = new Doctor("Dr Sharma", "Cardiologist", "LIC-12345");

        Appointment appointment = new Appointment();
        appointment.ScheduleAppointment(patient.Name);
        appointment.ScheduleAppointment(patient.Name, DateTime.Now);
        appointment.ScheduleAppointment(patient.Name, DateTime.Now, "Online");

        int age = patient.Age;
        string condition = "Unknown";
        string risk;

        DiagnosisService ds = new DiagnosisService();
        ds.Evaluate(in age, ref condition, out risk, 80, 90, 70);

        Console.WriteLine($"Condition: {condition}");
        Console.WriteLine($"Risk Level: {risk}");

        var bill = new BillingService
        {
            ConsultationFee = 500,
            TestCharges = 1200,
            RoomCharges = 3000
        };

        Console.WriteLine("Total Bill: " + bill.CalculateTotal());
        Console.WriteLine("Hospital Stay Days: " + TotalDays(5));
    }

    static int TotalDays(int day)
    {
        if (day == 0) return 0;
        return 1 + TotalDays(day - 1);
    }
}