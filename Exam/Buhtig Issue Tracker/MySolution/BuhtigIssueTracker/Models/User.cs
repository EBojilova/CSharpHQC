namespace BuhtigIssueTracker.Models
{
    using BuhtigIssueTracker.Utilities;

    public class User
    {
        public User(string username, string password)
        {
            this.UserName = username;
            this.UserPasswortHash = HashUtilities.HashPassword(password);
        }

        public string UserName { get; set; }

        public string UserPasswortHash { get; set; }
    }
}