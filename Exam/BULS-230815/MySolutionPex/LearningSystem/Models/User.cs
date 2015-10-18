namespace LearningSystem.Models
{
    using System.Collections.Generic;

    using LearningSystem.Utilities;

    public class User
    {
        private const int MinNameLength = 5;

        private const int MinPasswordLength = 6;

        private string passwordHash;

        private string username;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                Validations.ValidateArgumentLenght(value, "username", MinNameLength);
                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.passwordHash;
            }

            set
            {
                // TODO:
                Validations.ValidateArgumentLenght(value, "password", MinPasswordLength);
                value = HashUtilities.HashPassword(value);
                this.passwordHash = value;
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; }
    }
}