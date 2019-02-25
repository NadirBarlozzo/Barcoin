using Barcoin.Blockchain.Interface;
using Barcoin.Blockchain.Service;
using System;
using System.Collections.Generic;

namespace Barcoin.Blockchain.Model
{
    public class TransactionPool : ITransactionPool
    {
        public Queue<Transaction> Queue { get; set; }

        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public void QueueUp()
        {
            Queue = new Queue<Transaction>();

            TransactionRepository tr = new TransactionRepository();

            List<Transaction> transactions = tr.GetByPoolId(Id);

            foreach (Transaction t in transactions)
            {
                Add(t);
            }
        }

        public void Add(Transaction transaction)
        {
            Queue.Enqueue(transaction);
        }

        public Transaction GetFirst()
        {
            if(Queue.Count == 0)
            {
                QueueUp();
            }

            return Queue.Dequeue();
        }
    }
}
