using Barcoin.Blockchain.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Barcoin.Client.Service
{
    public class ChartSeriesRepository
    {
        public ObservableCollection<Transaction> BlockchainTransactions { get; set; }
        public int BlockchainTransactionsCount { get; set; }

        public SeriesCollection TransactionsDailyData { get; set; }
        public List<string> TransactionsDailyLabels { get; set; }

        public SeriesCollection CurrencyTradedDailyData { get; set; }

        public ChartSeriesRepository(ObservableCollection<Transaction> transactions)
        {
            BlockchainTransactions = transactions;
            BlockchainTransactionsCount = BlockchainTransactions.Count;

            TransactionsDailyData = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Daily Transactions",
                    Values = CountDailyTransactions()
                }
            };
        }

        private ChartValues<int> CountDailyTransactions()
        {
            var groups = BlockchainTransactions.GroupBy(x => x.Timestamp.Date);

            ChartValues<int> values = new ChartValues<int>();
            TransactionsDailyLabels = new List<string>();

            foreach (var group in groups)
            {
                values.Add(group.Count());

                TransactionsDailyLabels.Add(group.Key.ToString("yyyy.MM.dd"));
            }

            return values;
        }
    }
}
