using System;
namespace Project2.Core
{
class Appointment
{
    public void ScheduleAppointment(string patient)
    {
        Console.WriteLine($"Appointment Scheduled for patient {patient}");
    }
    public void ScheduleAppointment(string patient, DateTime date)
    {
        Console.WriteLine($"{patient} on {date}");
    }
    public void ScheduleAppointment(string patient, DateTime date , string mode)
    {
        Console.WriteLine($"{patient} on {date} via {mode}");
    }
}
}