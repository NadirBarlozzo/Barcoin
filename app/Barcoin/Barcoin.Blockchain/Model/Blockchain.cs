using Barcoin.Blockchain.Interface;
using Barcoin.Blockchain.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Barcoin.Blockchain.Model
{
    public class Blockchain : IBlockchain
    {
        public List<Block> Blocks { get; set; }

        public BlockRepository BlockRepository { get; set; }

        public Blockchain()
        {
            BlockRepository = new BlockRepository();

            Blocks = BlockRepository.Get();

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
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

            foreach(Block block in Blocks)
            {
                Transaction t = block.Pool.GetFirst();

                if (t.RecipientId == userId || t.SenderId == userId)
                {
                    transactions.Add(t);
                }
            }

            return transactions;
        }
    }
}
