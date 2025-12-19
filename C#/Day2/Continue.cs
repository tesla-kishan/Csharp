using System;
class conti
{
    static void Main()
    {
        for(int i=1 ;i <=10 ; i++)
        {
            if (i == 4)
            {
                Console.WriteLine("Enemy 4 is invisible Skipping Enemy 4");
                continue;
            } 
            Console.WriteLine("Player killed Enemy " + i);
        }
    }
}