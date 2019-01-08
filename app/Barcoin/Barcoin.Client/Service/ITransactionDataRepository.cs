using Barcoin.Client.Model;
using System.Collections.Generic;

namespace Barcoin.Client.Service
{
    interface ITransactionDataRepository : IBaseRepository<Transaction>
    {
        new List<Transaction> Get(int id);
    }
}
