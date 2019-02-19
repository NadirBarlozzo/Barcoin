using Barcoin.Blockchain.Model;
using System.Collections.Generic;

namespace Barcoin.Blockchain.Interface
{
    public interface ITransactionPool
    {
        void Add(Transaction transaction);

        void QueueUp();

        Transaction GetFirst();
    }
}
