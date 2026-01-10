using System;


sealed class Security
{
    public void Authenticate(string user, string pass)
    {
        if (user == "admin" && pass == "123")
            Console.WriteLine("User authenticated successfully");
        else
            Console.WriteLine("Authentication failed");
    }
}


// ---------------- BASE CLASS ----------------
abstract class InsurancePolicy
{
    // init only property
    public int PolicyNumber { get; init; }

    private double premium;
    public double Premium
    {
        get { return premium; }
        set
        {
            if (value > 0)
                premium = value;
            else
                throw new ArgumentException("Premium must be > 0");
        }
    }

    public string HolderName { get; set; }

    public virtual double CalculatePremium()
    {
        return Premium;
    }

    public void ShowPolicy()
    {
        Console.WriteLine("Insurance Policy");
    }
}


// ---------------- DERIVED 1 ----------------
class LifeInsurance : InsurancePolicy
{
    public override double CalculatePremium()
    {
        return Premium + 500;
    }

    public new void ShowPolicy()
    {
        Console.WriteLine("Life Insurance Policy");
    }
}


// ---------------- DERIVED 2 ----------------
class HealthInsurance : InsurancePolicy
{
    public override sealed double CalculatePremium()
    {
        return Premium + 2000;
    }
}


// ---------------- INDEXER CLASS ----------------
class PolicyDirectory
{
    private List<InsurancePolicy> policies = new List<InsurancePolicy>();

    public void Add(InsurancePolicy policy)
    {
        policies.Add(policy);
    }

    // index by numeric index
    public InsurancePolicy this[int index]
    {
        get { return policies[index]; }
    }

    // index by holder name
    public InsurancePolicy this[string name]
    {
        get
        {
            return policies.Find(p => p.HolderName == name);
        }
    }
}