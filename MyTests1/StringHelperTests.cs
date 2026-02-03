using Tests1;

namespace MyTests1;
[TestClass]
public class StringHelperTests
{
    [DataTestMethod]
    [DataRow("hello","olleh")]
    [DataRow("madam", "madam")]
    [DataRow("KL", "LK")]
    [DataRow("", "")]
    public void Reverse_Test(string input , string expected)
    {
        Assert.AreEqual(expected, new StringHelper().Reverse(input));
    }
}