namespace BuhtigIssueTracker.Utilities
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class HashUtility
    {
        public static string HashPassword(string password)
        {
            var sha1 = SHA1.Create();
            var hash = sha1
                .ComputeHash(Encoding.Default.GetBytes(password))
                .Select(x => x.ToString());
            return string.Join(string.Empty, hash);
        }
    }
}
