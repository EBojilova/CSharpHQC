using System;

using NUnit.Framework;

[TestFixture]
[Explicit]
public class TestBank
{
    [TestFixtureSetUp]
    [Ignore]
    public void Init()
    {
        // TODO: to be implemented
    }

    [TestFixtureTearDown]
    [Ignore]
    public void Dispose()
    {
        // TODO: to be implemented
    }

    [Test]
    public void TestBankAccountIndexer()
    {
        var bank = new Bank();
        var acc = new Account();
        bank.AddAccount(acc);
        var sameAcc = bank[0];
        Assert.AreSame(acc, sameAcc);

        var secondAcc = new Account();
        bank.AddAccount(secondAcc);
        var sameSecondAcc = bank[1];
        Assert.AreSame(secondAcc, sameSecondAcc);

        Assert.AreNotSame(sameAcc, sameSecondAcc);
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void TestBankAccountIndexerInvalidRange()
    {
        var bank = new Bank();
        var acc = new Account();
        bank.AddAccount(acc);
        var accFromBank = bank[1];
    }

    [Test]
    public void TestBankAddAccount()
    {
        var bank = new Bank();
        var acc = new Account();
        bank.AddAccount(acc);
        Assert.AreEqual(bank.AccountsCount, 1);
        Assert.AreSame(bank[0], acc);
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void TestBankAddNullAccount()
    {
        var bank = new Bank();
        bank.AddAccount(null);
    }

    [Test]
    public void TestBankAddRemoveAccount()
    {
        var bank = new Bank();
        var acc = new Account();
        bank.AddAccount(acc);
        Assert.AreEqual(bank.AccountsCount, 1);
        bank.RemoveAccount(acc);
        Assert.AreEqual(bank.AccountsCount, 0);
    }

    [Test]
    [Ignore]
    public void TestBankIgnoreTest()
    {
        // TODO: to be implemented
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void TestBankRemoveInvalidAccount()
    {
        var bank = new Bank();
        var acc = new Account();
        bank.AddAccount(acc);
        var anotherAcc = new Account();
        bank.RemoveAccount(anotherAcc);
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void TestBankRemoveNullAccount()
    {
        var bank = new Bank();
        bank.RemoveAccount(null);
    }
}