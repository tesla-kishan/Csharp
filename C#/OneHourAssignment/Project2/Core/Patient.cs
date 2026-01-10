namespace Project2.Core;
class Patient
{
    public int PatientId{get;}
    public string Name{get;set;}
    public int Age{get;set;}
    private String medicalHistory;
    public Patient()
    {
        PatientId=0;
    }
    public Patient(int id , string name)
    {
        PatientId=id;
        Name=name;
    }
    public Patient(int id, string name , int age)
    {
        PatientId=id;
        Name=name;
        Age=age;
    }
    public void SetMedicalHistory(string history)
    {
        medicalHistory = history;
    }
    public string GetMedicalHistory()
    {
        return medicalHistory;
    }

}
