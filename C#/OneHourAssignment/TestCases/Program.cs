using NUnit.Framework;
using System;

[TestFixture]   // Required attribute for class
public class UnitTest
{
    // 1. Deposit Valid
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program acc = new Program(1000m);

        acc.Deposit(500m);

        Assert.AreEqual(1500m, acc.Balance);
    }

    // 2. Deposit Negative
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program acc = new Program(1000m);

        Assert.Throws<Exception>(() => acc.Deposit(-100m));
    }

    // 3. Withdraw Valid
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program acc = new Program(1000m);

        acc.Withdraw(400m);

        Assert.AreEqual(600m, acc.Balance);
    }

    // 4. Withdraw Insufficient
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program acc = new Program(1000m);

        Assert.Throws<Exception>(() => acc.Withdraw(2000m));
    }
}