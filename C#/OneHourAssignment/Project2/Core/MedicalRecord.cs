class MedicalRecord
{
    private string diagnosis;
    private string history;
    public void AddRecord(string diag , string hist)
    {
        diagnosis=diag;
        history=hist;
    } 
    public void ViewRecord()
    {
        Console.WriteLine($"Diagnosis: {diagnosis}");
        Console.WriteLine($"History: {history}");
    }
}