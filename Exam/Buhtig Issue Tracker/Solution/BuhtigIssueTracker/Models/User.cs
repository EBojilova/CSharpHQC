namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using BuhtigIssueTracker.Utilities;

    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.PasswordHash = HashUtility.HashPassword(password);
        }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}
