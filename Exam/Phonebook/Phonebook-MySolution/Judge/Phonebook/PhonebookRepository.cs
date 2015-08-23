namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Interfaces;

    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly OrderedSet<PhoneEntry> repository = new OrderedSet<PhoneEntry>();

        private readonly Dictionary<string, PhoneEntry> repositoryByName = new Dictionary<string, PhoneEntry>();

        private readonly MultiDictionary<string, PhoneEntry> repositoryByPhoneNumber =
            new MultiDictionary<string, PhoneEntry>(false);

        public int CountOfPhoneEntries
        {
            get
            {
                return this.repository.Count;
            }
        }

        public int CountOfPhoneNumbersPerName
        {
            get
            {
                return this.repositoryByPhoneNumber.Count;
            }
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var nameLowerCase = name.ToLowerInvariant();
            PhoneEntry entry;
            var isPhoneAdded = !this.repositoryByName.TryGetValue(nameLowerCase, out entry);
            if (isPhoneAdded)
            {
                entry = new PhoneEntry { Name = name, PhonesPerName = new SortedSet<string>() };
                this.repositoryByName.Add(nameLowerCase, entry);

                this.repository.Add(entry);
            }

            foreach (var num in phoneNumbers)
            {
                this.repositoryByPhoneNumber.Add(num, entry);
            }

            entry.PhonesPerName.UnionWith(phoneNumbers);
            return isPhoneAdded;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var found = this.repositoryByPhoneNumber[oldNumber].ToList();
            foreach (var entry in found)
            {
                entry.PhonesPerName.Remove(oldNumber);
                this.repositoryByPhoneNumber.Remove(oldNumber, entry);

                entry.PhonesPerName.Add(newNumber);
                this.repositoryByPhoneNumber.Add(newNumber, entry);
            }

            return found.Count;
        }

        public PhoneEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.repository.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid range");
            }

            var selectedEntries = new PhoneEntry[count];

            for (var i = startIndex; i < startIndex + count; i++)
            {
                var entry = this.repository[i];
                selectedEntries[i - startIndex] = entry;
            }

            return selectedEntries;
        }
    }
}