using System;
using System.Security.Cryptography;

namespace Barcoin.Blockchain.Helper
{
    public class DigitalSignatureUtils
    {
        private static RSACryptoServiceProvider provider;

        private const string BASE_CONTAINER = "BRC-";

        public static void AssignKeyPair(string containerAddress)
        {
            CspParameters cp = new CspParameters
            {
                KeyContainerName = BASE_CONTAINER + containerAddress
            };

            provider = new RSACryptoServiceProvider(2048, cp);
        }

        public static bool RetrieveKeyPair(string containerAddress)
        {
            if(DoesKeyExists(BASE_CONTAINER + containerAddress))
            {
                AssignKeyPair(containerAddress);

                return true;
            }

            return false;
        }

        public static bool DoesKeyExists(string containerName)
        {
            var cp = new CspParameters
            {
                Flags = CspProviderFlags.UseExistingKey,
                KeyContainerName = containerName
            };

            try
            {
                var provider = new RSACryptoServiceProvider(cp);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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
