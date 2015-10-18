namespace BULS.Models
{
    using System;
    using System.Collections.Generic;

    using BULS.Utilities;

    public class User
    {
        private string password;

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
                if (string.IsNullOrEmpty(value))
                {
                    string message = "The username must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                if (value.Length < 5)
                {
                    string message = "The username must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    string message = "The password must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                if (value.Length < 5)
                {
                    string message = "The username must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this.password = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}