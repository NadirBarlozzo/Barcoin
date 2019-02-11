using System.Security.Cryptography;

namespace Barcoin.Blockchain.Helper
{
    public class HashUtils
    {
        private static readonly int saltLengthLimit = 32;

        public static byte[] GetSalt()
        {
            return GetSalt(saltLengthLimit);
        }

        public static byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

        public static byte[] ComputeHashSha256(byte[] data)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }
    }
}
