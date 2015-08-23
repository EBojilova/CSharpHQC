namespace Phonebook.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PhonebookRepositoryChangePhoneTests
    {
        private PhonebookRepository repository;

        [TestInitialize]
        public void InitializeTest()
        {
            this.repository = new PhonebookRepository();
        }

        [TestMethod]
        public void ChagePhoneShouldChangePhones()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            this.repository.AddPhone("Pesho", new[] { "+359899777235" });

            Assert.AreEqual(2, this.repository.ChangePhone("+359899777235", "+359899777236"));
            Assert.AreEqual(2, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersEntered);
        }

        [TestMethod]
        public void ChagePhoneDuplicatesShouldChangePhones()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            this.repository.AddPhone("Pesho", new[] { "+359899777235" });

            // oldNumber and newNumber are the same
            Assert.AreEqual(2, this.repository.ChangePhone("+359899777235", "+359899777235"));
            Assert.AreEqual(2, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersEntered);
        }

        [TestMethod]
        public void ChagePhoneNotExistingPhoneShouldNotChangePhones()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            this.repository.AddPhone("Pesho", new[] { "+359899777235" });

            // oldNumber is not existing
            Assert.AreEqual(0, this.repository.ChangePhone("+359899777234", "+359899777235"));
            Assert.AreEqual(2, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(2, this.repository.CountOfPhoneNumbersEntered);
        }

        [TestMethod]
        public void ChagePhoneShouldMergePhones()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });

            Assert.AreEqual(1, this.repository.ChangePhone("+35929811111", "+359899777235"));
            Assert.AreEqual(1, this.repository.CountOfPhoneEntries);
            Assert.AreEqual(1, this.repository.CountOfPhoneNumbersEntered);
        }
    }
}