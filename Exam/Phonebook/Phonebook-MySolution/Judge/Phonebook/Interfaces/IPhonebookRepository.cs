namespace Phonebook.Interfaces
{
    using System.Collections.Generic;

    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds a new entry to the phone book. 
        /// The entry should specify name and list of phones (at least 1 and at most 10). 
        /// The names in the phonebook are unique (duplicates are not accepted) and case-insensitive. 
        /// Adding phones for same name always performs merging: only the non-repeating canonical phones enter in the list of phones.
        /// </summary>
        /// <param name="name">The name will be non-empty English text (less than 200 characters) and 
        /// cannot contain ",", ":" and "\n", as well as leading or trailing whitespace. 
        /// Names are case-insensitive</param>
        /// <param name="phoneNumbers">The phone numbers will contain only digits, whitespace and 
        /// the special characters "+", "-", "/", "(" and ")". Phone numbers cannot contain "," and 
        /// "\n", leading or trailing whitespace. Phone numbers always have [3..50] digits. 
        /// Phone numbers could have at most one leading zero.</param>
        /// <returns>Outputs “Phone entry created” as a result when the name is missing in the phonebook and 
        /// "Phone entry merged" when the name already exists in the phonebook.</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes the specified old phone number in all phonebook entries with a new one. 
        /// Changing a phone number works with merging and thus any duplicating phone numbers are omitted.
        /// </summary>
        /// <param name="oldNumber">Cannonical phone number, e.g. +35988334455</param>
        /// <param name="newNumber">Cannonical phone number, e.g. +35988334455</param>
        /// <returns>Returns “X numbers changed” as a result,
        /// where X is the number of the changed old phone numbers in the system.</returns>
        int ChangePhone(string oldNumber, string newNumber);

        /// <summary>
        /// Lists the phonebook entries with paging. The page is specified by start index (zero-based) and 
        /// count in the phonebook assuming that the entries are sorted by name (case-insensitive). 
        /// The count specifies the page size (the number of phonebook entries to be retrieved). 
        /// </summary>
        /// <param name="startIndex">The start index is an integer number in the range [0…1000000].</param>
        /// <param name="count">The count is an integer number in the range [1…20].</param>
        /// <returns>The listed phonebook entries should be printed in the following form: "[name: phone1, phone2, …]", 
        /// each on a separate line. The name should appear in the same casing as when it was first added to the phonebook. 
        /// The phone numbers should be sorted alphabetically (as text). In case the start index is invalid or the count is invalid, 
        /// the command prints "Invalid range".</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">When the specified
        /// sub-range in invalid (invalid start position or invalid count)</exception>
        PhoneEntry[] ListEntries(int startIndex, int count);
    }
}