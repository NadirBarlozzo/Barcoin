using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Interface;
using Barcoin.Blockchain.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Barcoin.Blockchain.Model
{
    public class Block : IBlock
    {
        public TransactionPool Pool { get; set; }

        public int Id { get; set; }

        public int PoolId { get; set; }

        public string Signature { get; set; }

        public string Hash { get; set; }

        public string PreviousHash { get; set; }

        public DateTime Timestamp { get; set; }

        public void ComputeHash()
        {
            string body = "";

            int records = Pool.Queue.Count;

            for (int i = 0; i < records; i++)
            {
                string thash = Pool.Queue.Dequeue().ComputeHash();

                body += thash;
            }

            string header = Id + Timestamp.ToString() + PreviousHash;

            string blockHash = header + body;

            Hash = Convert.ToBase64String(
                HashUtils.ComputeHashSha256(
                    Encoding.UTF8.GetBytes(
                        blockHash
                    )
                )
            );
        }

        public bool IsValid(bool verbose = false)
        {
            BlockRepository br = new BlockRepository();

            List<Block> blocks = br.Get();

            int index = blocks.FindIndex(x => x.Id == Id);

            if (index != 0)
            {
                if (!PreviousHash.Equals(blocks[index - 1].Hash))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
