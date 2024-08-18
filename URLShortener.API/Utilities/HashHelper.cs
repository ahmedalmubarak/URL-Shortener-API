using System.Security.Cryptography;
using System.Text;

namespace TinyLink.API.Utilities
{
    public class HashHelper
    {
        public static string GenrateHash(string url)
        {
            return GenerateSHA512(url)[..8];
        }
        private static string GenerateSHA512(string input)
        {

            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
