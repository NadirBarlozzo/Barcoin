using System;
using System.Collections.Generic;
using System.Diagnostics;
using Launcher.Enum;
using Launcher.Helper;
using Launcher.Model;
using Launcher.Static;

namespace Launcher.Service
{
    public class TransactionDataRepository : ITransactionDataRepository
    {
        private readonly IDbHelper helper;

        public TransactionDataRepository()
        {
            if (Settings.Mode == Modality.Local)
            {
                helper = new SQLiteDatabaseHelper();
            }
            else
            {
                helper = new MySqlDatabaseHelper();
            }
        }

        public void Add(Transaction item)
        {
            int lastId = 0;
            string query = "";

            if (Settings.Mode == Modality.Local)
            {
                query = $"SELECT * FROM `transaction` ORDER BY" +
                    $" `transaction`.`transactionID` DESC LIMIT 1";

                lastId = int.Parse(helper.ProcessQuery(query)[0][0]);

                query = $"INSERT INTO `transaction` (`transactionID`, `date`, `principal`, `interestRate`, `description`," +
                    $" `ownerID`) VALUES('{lastId+1}', '{item.RawDate.ToString("yyyy-MM-dd")}', '{item.Principal}', " +
                    $"'{item.InterestRate}', '', '{item.TransactionID}')";
            }
            else
            {
                query = $"INSERT INTO `transaction` (`transactionID`, `date`, `principal`, `interestRate`, `description`," +
                    $" `ownerID`) VALUES('{lastId}', '{item.RawDate.ToString("yyyy-MM-dd")}', '{item.Principal}', " +
                    $"'{item.InterestRate}', '', '{item.TransactionID}')";
            }
 
            List<string[]> result = helper.ProcessQuery(query);
        }

        public void Delete(Transaction item)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> Get()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> Get(int id)
        {
            string query = $"SELECT * FROM `transaction` WHERE `transaction`.`ownerID` = '{id}' ORDER BY" +
                $" `transaction`.`date` ASC";

            List<string[]> result = helper.ProcessQuery(query);
            List<Transaction> transactions = new List<Transaction>();

            for (int i = 0; i < result.Count; i++)
            {
                Transaction t = new Transaction()
                {
                    TransactionID = int.Parse(result[i][0]),
                    RawDate = DateTime.Parse(result[i][1]),
                    Principal = int.Parse(result[i][2]),
                    InterestRate = double.Parse(result[i][3]),
                    Description = result[i][4]
                };

                transactions.Add(t);
            }

            return transactions;
        }

        Transaction IBaseRepository<Transaction>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
