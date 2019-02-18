using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barcoin.Blockchain.Service
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly QueryFactory db;

        public TransactionRepository()
        {
            DbHelper helper = new DbHelper();
            db = helper.GetFactory();
        }

        public int Add(Transaction item)
        {
            return db.Query("transaction").InsertGetId<int>(new
            {
                item.PoolId,
                item.SenderId,
                item.RecipientId,
                item.Amount,
                item.Status,
                item.Timestamp
            });
        }

        public Transaction Get(int id)
        {
            return Get().Find(x => x.Id == id);
        }

        public List<Transaction> Get()
        {
            return db.Query("transaction").Get<Transaction>().ToList();
        }

        public List<Transaction> GetByPoolId(int id)
        {
            return Get().FindAll(x => x.PoolId == id);
        }
    }
}
