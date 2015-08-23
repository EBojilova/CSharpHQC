namespace Phonebook.UnitTest
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PhonebookRepositoryListEntriesTests
    {
        private PhonebookRepository repository;

        [TestInitialize]
        public void InitializeTest()
        {
            this.repository = new PhonebookRepository();
        }

        [TestMethod]
        public void ListEntriesShouldReturntSelectedEntries()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            this.repository.AddPhone("KaLina", new[] { "+359899777235"});
            this.repository.AddPhone("Pesho", new[] { "+359899777235" });

            var listedEntries = this.repository.ListEntries(0, 2);

            Assert.AreEqual(2, listedEntries.Count());
            Assert.AreEqual("Kalina", listedEntries[0].Name);
            Assert.AreEqual("+35929811111, +359899777235", string.Join(", ", listedEntries[0].PhonesPerName));
            Assert.AreEqual("Pesho", listedEntries[1].Name);
            Assert.AreEqual("+359899777235", string.Join(", ", listedEntries[1].PhonesPerName));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesShouldTrowExepiton()
        {
            this.repository.AddPhone("Kalina", new[] { "+359899777235", "+35929811111" });
            this.repository.AddPhone("Pesho", new[] { "+359899777235" });
            this.repository.ListEntries(1, 2);
        }
    }
}