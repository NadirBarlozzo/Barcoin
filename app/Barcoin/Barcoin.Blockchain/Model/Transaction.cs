using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Interface;
using System;
using System.Text;

namespace Barcoin.Blockchain.Model
{
    public class Transaction : ITransaction
    {
        public int Id { get; set; }

        public int PoolId { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public float Amount { get; set; }

        public string Status { get; set; }

        public DateTime Timestamp { get; set; }

        public string ComputeHash()
        {
            string data = Id + PoolId + SenderId + RecipientId + Amount + Timestamp.ToString();

            return Convert.ToBase64String(
                HashUtils.ComputeHashSha256(
                    Encoding.UTF8.GetBytes(data)
                )
            );
        }
    }
}
