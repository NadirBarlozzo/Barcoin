using Barcoin.Blockchain.Model;
using System.Collections.Generic;

namespace Barcoin.Blockchain.Service
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        List<Transaction> GetByPoolId(int id);
    }
}
