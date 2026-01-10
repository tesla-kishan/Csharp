
using System;

class Program
{
    static void Main(string[] args)
    {
        SecurityModule.Authenticate();

        LifeInsurance life = new LifeInsurance(101, 5000, "Amit");
        HealthInsurance health = new HealthInsurance(102, 6000, "Neha");

        PolicyDirectory directory = new PolicyDirectory();
        directory.AddPolicy(life);
        directory.AddPolicy(health);


        Console.WriteLine(directory[0].PolicyHolderName); 
        Console.WriteLine(directory["Neha"]); 

        InsurancePolicy[] policies = { life, health };
        foreach (var p in policies)
        {
            if (p is LifeInsurance)
                Console.WriteLine($"Life Premium: {p.CalculatePremium()}");
            else if (p is HealthInsurance)
                Console.WriteLine($"Health Premium: {p.CalculatePremium()}");
        }


        life.DisplayPolicy(); 
        InsurancePolicy baseRef = life;
        baseRef.DisplayPolicy(); 
    }
}


