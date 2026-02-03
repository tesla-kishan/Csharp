namespace MyTests1;
[TestClass]
public class SumCalculatorTests
{
    [DataTestMethod]
    [DataRow(1,1)]
    [DataRow(10,55)]
    [DataRow(4,10)]
    [DataRow(0,0)]
    // [DataRow(12,43)]
    public void Sum_Test(int n , int expected)
    {
        Assert.AreEqual(expected, new SumCalculator().Sum(n));
    }
}