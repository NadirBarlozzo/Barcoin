using Barcoin.Blockchain.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Barcoin.Blockchain.Interface
{
    public interface IBlockchain
    {
        void AcceptBlock(Block block);

        ObservableCollection<Transaction> GetUserRelevantTransactions(int userId);

        bool IsValid();
    }
}
