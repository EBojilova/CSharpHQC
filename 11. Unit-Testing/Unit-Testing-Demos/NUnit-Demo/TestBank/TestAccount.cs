using System;

using NUnit.Framework;

[TestFixture]
public class TestAccount
{
    [Test]
    public void TestDeposit()
    {
        var acc = new Account();
        acc.Deposit(200.00F);
        var balance = acc.Balance;
        Assert.AreEqual(balance, 200F);
    }

    [Test]
    public void TestDepositNegative()
    {
        var acc = new Account();
        acc.Deposit(-150.30F);
        var balance = acc.Balance;
        Assert.AreEqual(balance, -150.30F);
    }

    [Test]
    public void TestDepositWithdrawTransferFunds()
    {
        var source = new Account();
        source.Deposit(200.00F);
        source.Withdraw(100.00F);

        var dest = new Account();
        dest.Deposit(150.00F);
        dest.Withdraw(50.00F);

        source.TransferFunds(dest, 100.00F);
        Assert.AreEqual(0.00F, source.Balance);
        Assert.AreEqual(200.00F, dest.Balance);
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void TestDepositZero()
    {
        var acc = new Account();
        acc.Deposit(0);
    }

    [Test]
    public void TestTransferFunds()
    {
        var source = new Account();
        source.Deposit(200.00F);
        var dest = new Account();
        dest.Deposit(150.00F);
        source.TransferFunds(dest, 100.00F);
        Assert.AreEqual(250.00F, dest.Balance);
        Assert.AreEqual(100.00F, source.Balance);
    }

    [Test]
    [ExpectedException(typeof(NullReferenceException))]
    public void TestTransferFundsFromNullAccount()
    {
        Account source = null;
        var dest = new Account();
        dest.Deposit(200.00F);
        source.TransferFunds(dest, 100.00F);
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void TestTransferFundsSameAccount()
    {
        var source = new Account();
        source.Deposit(200.00F);
        var dest = source;
        source.TransferFunds(dest, 100.00F);
    }

    [Test]
    [ExpectedException(typeof(NullReferenceException))]
    public void TestTransferFundsToNullAccount()
    {
        var source = new Account();
        source.Deposit(200.00F);
        Account dest = null;
        source.TransferFunds(dest, 100.00F);
    }

    [Test]
    public void TestWithdraw()
    {
        var acc = new Account();
        acc.Withdraw(138.56F);
        var balance = acc.Balance;
        Assert.AreEqual(balance, -138.56F);
    }

    [Test]
    public void TestWithdrawNegative()
    {
        var acc = new Account();
        acc.Withdraw(-3.14F);
        var balance = acc.Balance;
        Assert.AreEqual(balance, 1000F);
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void TestWithdrawZero()
    {
        var acc = new Account();
        acc.Withdraw(0);
    }
}