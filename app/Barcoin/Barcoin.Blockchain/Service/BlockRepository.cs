using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Barcoin.Blockchain.Service
{
    public class BlockRepository : IBlockRepository
    {
        private QueryFactory db;

        public BlockRepository()
        {
            DbHelper helper = new DbHelper();
            db = helper.GetFactory();
        }

        public int Add(Block item)
        {
            return db.Query("block").InsertGetId<int>(new
            {
                item.PoolId,
                item.Signature,
                item.Hash,
                item.PreviousHash,
                item.Timestamp
            });
        }

        public Block Get(int id)
        {
            return Get().Find(x => x.Id == id);
        }

        public List<Block> Get()
        {
            return db.Query("block").Get<Block>().ToList();
        }
    }
}
