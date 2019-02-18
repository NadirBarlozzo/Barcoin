using System.Collections.Generic;
using System.Linq;
using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using SqlKata.Execution;

namespace Barcoin.Blockchain.Service
{
    public class TransactionPoolRepository : ITransactionPoolRepository
    {
        private readonly QueryFactory db;

        public TransactionPoolRepository()
        {
            DbHelper helper = new DbHelper();
            db = helper.GetFactory();
        }

        public int Add(TransactionPool item)
        {
            return db.Query("pool").InsertGetId<int>(new
            {
                item.Timestamp
            });
        }

        public TransactionPool Get(int id)
        {
            return Get().Find(x => x.Id == id);
        }

        public List<TransactionPool> Get()
        {
            return db.Query("pool").Get<TransactionPool>().ToList();
        }
    }
}
