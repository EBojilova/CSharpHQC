namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneEntry : IComparable<PhoneEntry>
    {
        // The SortedSet<T> class does not accept duplicate elements. 
        // If item is already in the set, this method returns false and does not throw an exception.
        public SortedSet<string> PhonesPerName { get; set; }

        public string Name { get; set; }

        public int CompareTo(PhoneEntry other)
        {
            return string.Compare(this.Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            // [Kalina: +35929811111, +359899777235, +359899777236]
            sb.AppendFormat("[{0}: {1}]", this.Name, string.Join(", ", this.PhonesPerName));

            return sb.ToString();
        }
    }
}