using Barcoin.Blockchain.Enum;
using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Interface;
using Barcoin.Blockchain.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Barcoin.Blockchain.Model
{
    public class Blockchain : IBlockchain
    {
        public List<Block> Blocks { get; set; }

        public List<User> Users { get; set; }

        public BlockRepository BlockRepository { get; set; }

        public UserRepository UserRepository { get; set; }

        public Blockchain()
        {
            BlockRepository = new BlockRepository();
            UserRepository = new UserRepository();

            Blocks = BlockRepository.Get();
            Users = UserRepository.Get();

            foreach (Block block in Blocks)
            {
                block.AssignPool();
            }
        }

        public void AcceptBlock(Block block)
        {
            BlockRepository.Add(block);
        }

        public bool IsValid()
        {
            bool isValid = true;

            foreach (Block block in Blocks)
            {
                if (!block.IsValid())
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public ObservableCollection<Transaction> GetUserRelevantTransactions(int userId)
        {
            ObservableCollection<Transaction> transactions = GetTransactions();

            ObservableCollection<Transaction> relevantTransactions = new ObservableCollection<Transaction>();

            foreach (Transaction t in transactions)
            {
                if (t.RecipientId == userId || t.SenderId == userId)
                {
                    relevantTransactions.Add(t);
                }
            }

            return relevantTransactions;
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

            foreach (Block block in Blocks)
            {
                Transaction t = block.Pool.GetFirst();

                transactions.Add(t);
            }

            return transactions;
        }

        public string GetUsernameById(int userId)
        {
            return UserRepository.Get(userId).Username;
        }

        public Block GenerateBlock(int senderId, int recipientId, float amount)
        {
            TransactionPoolRepository tpr = new TransactionPoolRepository();

            TransactionPool tp = new TransactionPool
            {
                Timestamp = DateTime.Now
            };

            int poolId = tpr.Add(tp);

            TransactionRepository tr = new TransactionRepository();

            Transaction t = new Transaction
            {
                PoolId = poolId,
                SenderId = senderId,
                RecipientId = recipientId,
                Amount = amount,
                Status = TransactionStatus.confirmed.ToString(),
                Timestamp = DateTime.Now
            };

            int transactionId = tr.Add(t);

            Block b = new Block
            {
                PoolId = poolId,
                PreviousHash = Blocks.Last().Hash,
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

            return b;
        }

        public int GetIdFromAddress(string address)
        {
            User target = Users.Find(x => x.Address.Equals(address));

            if(target != null)
            {
                return target.Id;
            }

            return -1;
        }
    }
}
