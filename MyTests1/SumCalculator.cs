namespace MyTests1;
public class SumCalculator
{
    public int Sum(int n)
    {
        int sum=0;
        for(int i=1 ; i<=n ; i++)
        {
            sum += i;
        }
        return sum;
    }
}