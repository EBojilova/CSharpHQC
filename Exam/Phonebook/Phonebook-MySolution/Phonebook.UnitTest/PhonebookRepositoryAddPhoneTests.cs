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
        public void AddPhoneReturnsTrue()
        {
            // AddPhone(Kalina, 0899 777 235, 02 / 981 11 11)
            var isPhoneAdded = this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });

            Assert.IsTrue(isPhoneAdded);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersEntered);

            isPhoneAdded = this.repository.AddPhone("Pesho", new[] { "+359899777235", "+35929811111" });

            Assert.IsTrue(isPhoneAdded);
            Assert.AreEqual(2, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersEntered);
        }

        [TestMethod]
        public void AddPhoneDuplicateReturnsFalse()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });

            var isPhoneAdded = this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });

            Assert.AreEqual(false, isPhoneAdded);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersEntered);

            isPhoneAdded = this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });

            Assert.IsFalse(isPhoneAdded);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersEntered);
        }

        [TestMethod]
        public void AddPhoneReturnsDifferentCasing()
        {
            // AddPhone(Kalina, 0899 777 235, 02 / 981 11 11)
            // AddPhone(kalina, +359899777235)
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            var isPhoneAdded = this.repository.AddPhone("kalina", new[] { "+359899777235" });

            Assert.IsFalse(isPhoneAdded);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersEntered);
        }

        [TestMethod]
        public void AddPhoneReturnsMerge()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            var isPhoneAdded = this.repository.AddPhone("kalina", new[] { "+359899777236" });

            Assert.IsFalse(isPhoneAdded);
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(3, this.repository.CountOfPhoneNumbersEntered);
        }
    }
}