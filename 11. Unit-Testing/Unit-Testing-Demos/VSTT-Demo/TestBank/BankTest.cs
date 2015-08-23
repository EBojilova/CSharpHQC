using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestBank
{
    [TestClass]
    public class BankTest
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

        // Test constructor of the class Bank
        // Ako testa ne mine za 2 sekudi ste feilne
        [TestMethod]
        [Timeout(2000)]
        public void TestBanShouldHaveNotNullAcoounts()
        {
            //// Arrange
            Bank bank = new Bank();
            //// Act- nothing to do at the moment
            //// Assert
            Assert.IsNotNull(bank, "The bank is null.");
            Assert.AreEqual(bank.AccountsCount, 0, "The bank accouts are not zero initially.");
        }
        
        [TestMethod]
        public void TestBankAddAccount()
        {
            //// Arrange
            Bank bank = new Bank();
            Account acc = new Account();
            //// Act
            bank.AddAccount(acc);
            //// Assert
            Assert.AreEqual(bank.AccountsCount, 1, "Account is not added.");
            Assert.AreSame(bank[0], acc);
            ////Assert.IsTrue(bank.AccountsCount != 0, "The account was not added to the bank.");
        }

        [TestMethod]
        public void TestBankAddMoreAccounts()
        {
            //// Arrange + Act
            var accountsCount = 10;
            Bank bank = new Bank();
            for (int i = 0; i < accountsCount; i++)
            {
                var account = new Account();
                bank.AddAccount(account);
            }
            //// Assert
            Assert.AreEqual(bank.AccountsCount, accountsCount, "Not all accounts are added");
            Assert.IsTrue(bank.AccountsCount != 0, "The accounts was were not added to the bank.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBankAddNullAccount()
        {
            Bank bank = new Bank();
            bank.AddAccount(null);
        }

        [TestMethod]
        public void TestBankAddRemoveAccount()
        {
            Bank bank = new Bank();
            Account acc = new Account();
            bank.AddAccount(acc);
            Assert.AreEqual(bank.AccountsCount, 1);
            bank.RemoveAccount(acc);
            Assert.AreEqual(bank.AccountsCount, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBankRemoveInvalidAccount()
        {
            Bank bank = new Bank();
            Account acc = new Account();
            bank.AddAccount(acc);
            Account anotherAcc = new Account();
            bank.RemoveAccount(anotherAcc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBankRemoveNullAccount()
        {
            Bank bank = new Bank();
            bank.RemoveAccount(null);
        }

        [TestMethod]
        public void TestBankAccountIndexer()
        {
            Bank bank = new Bank();
            Account acc = new Account();
            bank.AddAccount(acc);
            Account sameAcc = bank[0];
            Assert.AreSame(acc, sameAcc);

            Account secondAcc = new Account();
            bank.AddAccount(secondAcc);
            Account sameSecondAcc = bank[1];
            Assert.AreSame(secondAcc, sameSecondAcc);

            Assert.AreNotSame(sameAcc, sameSecondAcc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBankAccountIndexerInvalidRange()
        {
            Bank bank = new Bank();
            Account acc = new Account();
            bank.AddAccount(acc);
            Account accFromBank = bank[1];
        }

        [TestMethod]
        [Ignore]
        public void TestBankIgnoreTest()
        {
            // This test is not executed
        }
    }
}
