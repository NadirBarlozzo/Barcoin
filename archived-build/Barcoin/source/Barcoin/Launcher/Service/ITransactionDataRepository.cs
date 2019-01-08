using Launcher.Model;
using System.Collections.Generic;

namespace Launcher.Service
{
    interface ITransactionDataRepository : IBaseRepository<Transaction>
    {
        new List<Transaction> Get(int id);
    }
}
