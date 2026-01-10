namespace Project2.Services;

class DiagnosisService
{
    public void Evaluate(
        in int age,
        ref string condition,
        out string risk,
        params int []tests)
    {
        int total=0;
        foreach(int t in tests)
        {
            total+=t;
        }
        risk = total>200 ? "High" : "Low";
        condition = age>60 ? "Critical" : "Stable";

    }
}