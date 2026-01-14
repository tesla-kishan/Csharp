

//////////////////// DELEGATES ////////////////////
public delegate string ReportGenerator(string patientName);
public delegate void HospitalAlert(string message);
public delegate void HospitalNotificationHandler(string message, DateTime time);

//////////////////// EVENT PUBLISHER ////////////////////
public class HospitalNotifier
{
    public event HospitalNotificationHandler PatientAdmitted;

    public void AdmitPatient(string name)
    {
        if (PatientAdmitted != null)
        {
            string msg = "Patient " + name + " admitted successfully.";
            PatientAdmitted(msg, DateTime.Now);
        }
    }
}

//////////////////// EVENT SUBSCRIBER ////////////////////
public class AdministrationDepartment
{
    public void Notify(string message, DateTime time)
    {
        Console.WriteLine("[ADMIN] " + message + " | " + time);
    }
}