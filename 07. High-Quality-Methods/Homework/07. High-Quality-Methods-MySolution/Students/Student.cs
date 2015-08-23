namespace Students
{
    using System;
    using System.Text.RegularExpressions;

    internal class Student
    {
        private string dateOfBirth;

        private string firstName;

        private string lastName;

        private string otherInfo;

        public Student(string firstName, string lastName, string dateOfBirth, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("firstName", "First name cannot be empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("lastName", "Last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Please enter additional information for the student.");
                }

                this.otherInfo = value;
            }
        }

        public string DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                var isDateOfBirthCorrectFormat = Regex.IsMatch(value, @"\d{2}.\d{2}.\d{4}");
                if (!isDateOfBirthCorrectFormat)
                {
                    throw new InvalidCastException("Date should be in format dd.MM.yyyy");
                }

                this.dateOfBirth = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            var isOlderThan = DateTime.Parse(this.DateOfBirth) < DateTime.Parse(other.DateOfBirth);
            return isOlderThan;
        }
    }
}