using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Barcoin.Blockchain.Enum;
using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using Barcoin.Blockchain.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barcoin.Tests
{
    [TestClass]
    public class BlockchainUnit
    {
        [TestMethod]
        public void SignatureValidationBetweenTwoUsers()
        {
            //User1
            DigitalSignatureUtils.AssignKeyPair("addr1");

            //User1 public key
            var pubKey = DigitalSignatureUtils.RetrievePublicKey();

            //Hashed data
            var hash = HashUtils.ComputeHashSha256(Encoding.UTF8.GetBytes("TestData"));

            //User1 signatured data
            var signature = DigitalSignatureUtils.SignData(hash);

            //User2
            DigitalSignatureUtils.AssignKeyPair("addr2");

            //Data validation
            var isValid = DigitalSignatureUtils.VerifySignature(hash, signature, pubKey);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void SignatureKeyCheck()
        {
            DigitalSignatureUtils.RetrieveKeyPair("addr1");

            var pubKey = DigitalSignatureUtils.RetrievePublicKey();

            Assert.IsTrue(pubKey != null);
        }

        [TestMethod]
        public void RepositoriesFullInsert()
        {
            DigitalSignatureUtils.AssignKeyPair("addr3");

            TransactionPoolRepository tpr = new TransactionPoolRepository();

            TransactionPool tp = new TransactionPool
            {
                Timestamp = DateTime.Now
            };

            int poolId = tpr.Add(tp);

            Assert.AreEqual(poolId, tpr.Get(poolId).Id);

            TransactionRepository tr = new TransactionRepository();

            Transaction t = new Transaction
            {
                PoolId = poolId,
                SenderId = 2,
                RecipientId = 3,
                Amount = 2,
                Status = TransactionStatus.confirmed.ToString(),
                Timestamp = DateTime.Now
            };

            int transactionId = tr.Add(t);

            Assert.AreEqual(transactionId, tr.Get(transactionId).Id);

            BlockRepository br = new BlockRepository();

            Block b = new Block
            {
                PoolId = poolId,
                PreviousHash = br.Get().Last().Hash,
                Timestamp = DateTime.Now
            };

            b.AssignPool();

            b.ComputeHash();

            b.Signature = Convert.ToBase64String(
                DigitalSignatureUtils.SignData(
                    Convert.FromBase64String(
                        b.Hash
                    )
                )
            );

            int blockId = br.Add(b);

            Assert.AreEqual(blockId, br.Get(blockId).Id);
        }
    
        [TestMethod]
        public void ValidateBlockchain()
        {
            BlockRepository br = new BlockRepository();
            
            List<Block> blocks = br.Get();

            bool isValid = true;

            foreach (Block block in blocks)
            {
                if (!block.IsValid())
                {
                    isValid = false;
                }
            }

            Assert.IsTrue(isValid);
        }
    }
}
