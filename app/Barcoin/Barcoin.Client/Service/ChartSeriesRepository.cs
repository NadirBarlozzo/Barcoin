using Barcoin.Blockchain.Model;
using Barcoin.Client.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Barcoin.Client.Service
{
    public class ChartSeriesRepository
    {
        public IEnumerable<Transaction> BlockchainTransactions { get; set; }
        public ObservableCollection<CustomTransaction> UserTransactions { get; set; }

        public SeriesCollection DailyCurrencyTraded { get; set; }
        public SeriesCollection DailyTransactions { get; set; }
        public SeriesCollection DailyBalances { get; set; }

        public List<string> Labels { get; set; }

        public ChartSeriesRepository(IEnumerable<Transaction> transactionsB, ObservableCollection<CustomTransaction> transactionsU)
        {
            BlockchainTransactions = transactionsB;
            UserTransactions = transactionsU;

            ComputeChartsDatapoints();
        }

        private void ComputeChartsDatapoints()
        {
            var globalGroups = BlockchainTransactions
                .OrderBy(x => x.Timestamp.Date)
                .GroupBy(x => x.Timestamp.Date);

            ChartValues<int> dailyTransactions = new ChartValues<int>();
            ChartValues<double> dailyCurrencyTraded = new ChartValues<double>();
            ChartValues<double> dailyReceivedCurrency = new ChartValues<double>();
            ChartValues<double> dailySentCurrency = new ChartValues<double>();

            Labels = new List<string>();

            foreach (var group in globalGroups)
            {
                dailyTransactions.Add(group.Count());

                double sum = 0;

                for (int i = 0; i < group.Count(); i++)
                {
                    Transaction t = group.ElementAt(i);

                    sum += t.Amount;
                }

                dailyCurrencyTraded.Add(Math.Round(sum, 4));

                Labels.Add(group.Key.ToString("yyyy.MM.dd"));
            }

            var ownGroups = UserTransactions
                .OrderBy(x => Convert.ToDateTime(x.Timestamp).Date)
                .GroupBy(x => Convert.ToDateTime(x.Timestamp).Date);

            foreach (var group in ownGroups)
            {
                double sumReceived = 0;
                double sumSent = 0;

                for (int i = 0; i < group.Count(); i++)
                {
                    CustomTransaction ct = group.ElementAt(i);

                    if (ct.Recipient.Equals("You"))
                    {
                        sumReceived += ct.Amount;
                    }
                    else
                    {
                        sumSent += ct.Amount;
                    }
                }

                dailyReceivedCurrency.Add(Math.Round(sumReceived, 4));
                dailySentCurrency.Add(Math.Round(sumSent, 4));
            }

            DailyTransactions = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Daily Global Transactions",
                    Values = dailyTransactions
                }
            };

            DailyCurrencyTraded = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Daily Global BRC Traded",
                    Values = dailyCurrencyTraded
                }
            };

            DailyBalances = new SeriesCollection()
            {
                new StackedColumnSeries()
                {
                    Title = "Received Currency",
                    Values = dailyReceivedCurrency
                },

                new StackedColumnSeries()
                {
                    Title = "Sent Currency",
                    Values = dailySentCurrency
                }
            };
        }
    }
}
