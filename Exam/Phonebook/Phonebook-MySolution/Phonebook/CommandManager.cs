namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Phonebook.Interfaces;

    internal class CommandManager
    {
        private const string BulgariaCode = "+359";

        private readonly IPhonebookRepository repository = new PhonebookRepository();

        private StringBuilder output = new StringBuilder();

        public StringBuilder Output
        {
            get
            {
                return this.output;
            }

            set
            {
                this.output = value;
            }
        }

        public void ProceedCommands(string data)
        {
            var i = data.IndexOf('(');
            if (i == -1 || !data.EndsWith(")"))
            {
                throw new ArgumentException(string.Format("Invalid command: {0}", data));
            }

            var command = data.Substring(0, i).Trim();
            var commandParameterString = data.Substring(i + 1, data.Length - (i + 1) - 1);
            var commandParameters = commandParameterString.Split(',').Select(p => p.Trim()).ToArray();

            if (command == "AddPhone" && commandParameters.Length >= 2 && commandParameters.Length <= 11)
            {
                this.ProceedAddPhoneCommand(commandParameters);
            }
            else if (command == "ChangePhone" && commandParameters.Length == 2)
            {
                this.ProceedChangePhoneCommand(commandParameters);
            }
            else if (command == "List" && commandParameters.Length == 2)
            {
                this.ProceedListCommand(commandParameters);
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid command: {0}", command));
            }
        }

        private static string FormatPhoneNumber(string phoneNumber)
        {
            // Skip all non-digit characters except '+'
            // Example: (+359) 888 999 111 --> +359888999111
            var sb = new StringBuilder();
            foreach (var ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    sb.Append(ch);
                }
            }

            if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
            {
                // The phone number starts with "00", replace it with "+"
                // Example: 00359888999111 --> +359888999111
                sb.Remove(0, 1);
                sb[0] = '+';
            }

            while (sb.Length > 0 && sb[0] == '0')
            {
                // Remove any leading zeros
                // Example: 0894778899 --> 894778899
                // sb.ToString().TrimStart('0');
                sb.Remove(0, 1);
            }

            if (sb.Length > 0 && sb[0] != '+')
            {
                // Insert the default country code the first char is not "+"
                // Example: 894778899 --> +359894778899
                sb.Insert(0, BulgariaCode);
            }

            var cannonicalPhoneNumber = sb.ToString();
            return cannonicalPhoneNumber;
        }

        private void ProceedAddPhoneCommand(IReadOnlyList<string> commandParameters)
        {
            var name = commandParameters[0];
            var phones = commandParameters.Skip(1).Select(FormatPhoneNumber);
            var isPhoneAdded = this.repository.AddPhone(name, phones);
            this.output.AppendLine(isPhoneAdded ? "Phone entry created" : "Phone entry merged");
        }

        private void ProceedChangePhoneCommand(IReadOnlyList<string> commandParameters)
        {
            var oldNumber = FormatPhoneNumber(commandParameters[0]);
            var newNumber = FormatPhoneNumber(commandParameters[1]);
            var numbersChanged = this.repository.ChangePhone(oldNumber, newNumber);
            this.output.AppendLine(string.Format("{0} numbers changed", numbersChanged));
        }

        private void ProceedListCommand(IReadOnlyList<string> commandParameters)
        {
            try
            {
                var startIndex = int.Parse(commandParameters[0]);
                var count = int.Parse(commandParameters[1]);
                IEnumerable<PhoneEntry> entries = this.repository.ListEntries(startIndex, count);
                this.output.AppendLine(string.Join(Environment.NewLine, entries));
            }
            catch (ArgumentOutOfRangeException)
            {
                this.output.AppendLine("Invalid range");
            }
        }
    }
}