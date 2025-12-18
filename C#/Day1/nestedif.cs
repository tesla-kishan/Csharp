using System;
class nestedif
{
    static void Main()
    {
        int age = 22;
        bool hasLicense = true;
        if (age >= 18)
        {
            if (hasLicense)
            {
                Console.WriteLine("You are allowed");
            }
        }
        else Console.WriteLine("License Required");
    }
}