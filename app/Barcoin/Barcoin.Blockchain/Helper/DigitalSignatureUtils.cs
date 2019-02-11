using System.Security.Cryptography;

namespace Barcoin.Blockchain.Helper
{
    public class DigitalSignatureUtils
    {
        private static RSACryptoServiceProvider provider;

        private const string BASE_CONTAINER = "BRC-";

        public static void AssignOrRetrieveKeyPair(string containerAddress)
        {
            CspParameters cp = new CspParameters
            {
                KeyContainerName = BASE_CONTAINER + containerAddress
            };

            provider = new RSACryptoServiceProvider(2048, cp);
        }

        public static byte[] SignData(byte[] hash)
        {
            var rsaFormatter = new RSAPKCS1SignatureFormatter(provider);
            rsaFormatter.SetHashAlgorithm("SHA256");

            return rsaFormatter.CreateSignature(hash);
        }

        public static bool VerifySignature(byte[] hash, byte[] signature, string pubKey = null)
        {
            if (pubKey != null)
            {
                provider.FromXmlString(pubKey);
            }

            var rsaDeformatter = new RSAPKCS1SignatureDeformatter(provider);
            rsaDeformatter.SetHashAlgorithm("SHA256");

            return rsaDeformatter.VerifySignature(hash, signature);
        }

        public static string RetrievePublicKey()
        {
            return provider.ToXmlString(false);
        }
    }
}
