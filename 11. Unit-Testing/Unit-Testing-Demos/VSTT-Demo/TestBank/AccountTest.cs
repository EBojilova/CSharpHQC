namespace TestBank
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AccountTest
    {
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize]
        public void TestInitialize()
        {
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void TestDeposit()
        {
            var acc = new Account();
            acc.Deposit(200.00M);
            var balance = acc.Balance;
            Assert.AreEqual(balance, 200.00M);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositZero()
        {
            var acc = new Account();
            acc.Deposit(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositNegative()
        {
            var acc = new Account();
            acc.Deposit(-150.30M);
            var balance = acc.Balance;
            Assert.AreEqual(balance, -150.30M);
        }

        [TestMethod]
        public void TestWithdraw()
        {
            var acc = new Account();
            acc.Withdraw(138.56M);
            var balance = acc.Balance;
            Assert.AreEqual(balance, -138.56M);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithdrawZero()
        {
            var acc = new Account();
            acc.Withdraw(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithdrawNegative()
        {
            var acc = new Account();
            acc.Withdraw(-3.14M);
            var balance = acc.Balance;
            Assert.AreEqual(balance, 3.14M);
        }

        [TestMethod]
        public void TestTransferFunds()
        {
            var source = new Account();
            source.Deposit(200.00M);
            var dest = new Account();
            dest.Deposit(150.00M);
            source.TransferFunds(dest, 100.00M);
            Assert.AreEqual(250.00M, dest.Balance);
            Assert.AreEqual(100.00M, source.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestTransferFundsFromNullAccount()
        {
            Account source = null;
            var dest = new Account();
            dest.Deposit(200.00M);
            source.TransferFunds(dest, 100.00M);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestTransferFundsToNullAccount()
        {
            var source = new Account();
            source.Deposit(200.00M);
            Account dest = null;
            source.TransferFunds(dest, 100.00M);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTransferFundsSameAccount()
        {
            var source = new Account();
            source.Deposit(200.00M);
            var dest = source;
            source.TransferFunds(dest, 100.00M);
        }

        [TestMethod]
        public void TestDepositWithdrawTransferFunds()
        {
            var source = new Account();
            source.Deposit(200.00M);
            source.Withdraw(100.00M);

            var dest = new Account();
            dest.Deposit(150.00M);
            dest.Withdraw(50.00M);

            source.TransferFunds(dest, 100.00M);
            Assert.AreEqual(0.00M, source.Balance);
            Assert.AreEqual(200.00M, dest.Balance);
        }
    }
}