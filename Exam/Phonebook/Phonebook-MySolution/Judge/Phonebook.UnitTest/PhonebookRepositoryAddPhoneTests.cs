namespace Phonebook.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PhonebookRepositoryAddPhoneTests
    {
        private PhonebookRepository repository;

        [TestInitialize]
        public void InitializeTest()
        {
            this.repository = new PhonebookRepository();
        }

        [TestMethod]
        public void TestAddPhoneReturnsTrue()
        {
            // AddPhone(Kalina, 0899 777 235, 02 / 981 11 11)
            var cmdResult = this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });

            Assert.AreEqual(true, cmdResult);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersPerName);
        }

        [TestMethod]
        public void TestAddPhoneDuplicateReturnsFalse()
        {
            var cmdResult = this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            Assert.AreEqual(true, cmdResult);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersPerName);
            cmdResult = this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            Assert.AreEqual(false, cmdResult);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersPerName);
            cmdResult = this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            Assert.AreEqual(false, cmdResult);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersPerName);
        }

        [TestMethod]
        public void TestAddPhoneReturnsDifferentCasing()
        {
            // AddPhone(Kalina, 0899 777 235, 02 / 981 11 11)
            // AddPhone(kalina, +359899777235)
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            var cmdResult = this.repository.AddPhone("kalina", new[] { "+359899777235" });

            Assert.AreEqual(false, cmdResult);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersPerName);
        }

        [TestMethod]
        public void TestAddPhoneReturnsMerge()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            var cmdResult = this.repository.AddPhone("kalina", new[] { "+359899777236" });

            Assert.AreEqual(false, cmdResult);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(3, this.repository.CountOfPhoneNumbersPerName);
        }
    }
}