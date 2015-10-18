namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Utilities;

    public class User
    {
        private string passwordHash;

        private string username;

        public User(string username, string password, Role role)
        {
            this.UserName = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string UserName
        {
            get
            {
                return this.username;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    var message = "The username must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    var message = "The password must be at least 6 symbols long.";
                    throw new ArgumentException(message);
                }

                this.passwordHash = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; }
    }
}