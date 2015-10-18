namespace LearningSystem.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public static class HashUtilities
    {
        public static string HashPassword(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var sha1 = SHA1.Create();
            var hashBytes = sha1.ComputeHash(bytes);
            return HexStringFromBytes(hashBytes);
        }

        private static string HexStringFromBytes(byte[] bytes)
        {
            var result = new StringBuilder();
            foreach (var b in bytes)
            {
                result.Append(b.ToString("x2"));
            }

            return result.ToString();
        }
    }
}