using Barcoin.Blockchain.Model;
using System.Collections.ObjectModel;

namespace Barcoin.Blockchain.Interface
{
    public interface IBlockchain
    {
        void AcceptBlock(Block block);

        ObservableCollection<Transaction> GetUserRelevantTransactions(int userId);

        Block GenerateBlock(int senderId, int recipientId, float amount);

        bool IsValid();

        int GetIdFromAddress(string address);
    }
}
