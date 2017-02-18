using System.Security.Cryptography;
using System.Text;

namespace WatchShop.Domain.Identities
{
    internal static class Cryptographer
    {
        private const string LowerCase = "x2";

        public static string Encode(string value)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));
                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString(LowerCase));
                }

                return sb.ToString();
            }
        }
    }
}