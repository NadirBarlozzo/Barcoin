using Barcoin.Client.Model;
using Barcoin.Client.Service;
using LiveCharts;
using LiveCharts.Wpf;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.IO;
using System.Windows;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace Barcoin.Client.ViewModel
{
    public class DetailViewModel : BindableBase
    {
        public IDelegateCommand AddTransactionCommand { get; set; }
        public IDelegateCommand PrintCommand { get; set; }
        public IDelegateCommand ExportCommand { get; set; }

        public List<string> Dates { get; set; }
        public List<double> TotalOwedKeypoints { get; set; }
        public List<double> PrincipalKeypoints { get; set; }

        public ObservableCollection<Transaction> Transactions { get; set; }

        //public CreditorDataRepository RepoCreditors { get; private set; }
        //public TransactionDataRepository RepoTransactions { get; private set; }

        public Creditor SelectedCreditor { get; set; }

        private ObservableCollection<Balance> balanceData;

        public ObservableCollection<Balance> BalanceData
        {
            get { return balanceData; }
            set { SetProperty(ref balanceData, value); }
        }

        private SeriesCollection graphicData;

        public SeriesCollection GraphData
        {
            get { return graphicData; }
            set { SetProperty(ref graphicData, value); }
        }

        private DateTime newDate = DateTime.Now;

        public DateTime NewDate
        {
            get { return newDate; }
            set { SetProperty(ref newDate, value); }
        }

        private string newPrincipal;

        public string NewPrincipal
        {
            get { return newPrincipal; }
            set { SetProperty(ref newPrincipal, value); }
        }

        private string newInterestRate;

        public string NewInterestRate
        {
            get { return newInterestRate; }
            set { SetProperty(ref newInterestRate, value); }
        }

        public DetailViewModel()
        {
            Messenger.Default.Register<Creditor>(this, OnSentCreditor);

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            AddTransactionCommand = new DelegateCommand(OnAdd);
            PrintCommand = new DelegateCommand(OnPrint);
            ExportCommand = new DelegateCommand(OnExport);
        }

        private void OnPrint(object obj)
        {
            PrintPDF();
        }

        private void OnExport(object obj)
        {
            ExportCSV($"./ExportedTransactions/{SelectedCreditor.CreditorName}{SelectedCreditor.CreditorSurname}-Transactions.csv");
        }

        private void OnAdd(object obj)
        {
            Transaction t = new Transaction()
            {
                TransactionID = SelectedCreditor.CreditLineID,
                RawDate = NewDate,
                Principal = int.Parse(NewPrincipal),
                InterestRate = double.Parse(NewInterestRate)
            };

            //RepoTransactions.Add(t);

            UpdateStatus();
        }

        private void OnSentCreditor(Creditor obj)
        {
            //RepoCreditors = new CreditorDataRepository();
            //RepoTransactions = new TransactionDataRepository();

            SelectedCreditor = obj;
            ViewModelLocator.Main.CurrentViewModel = this;

            UpdateStatus();

            Timer timer = new Timer(60000);
            timer.Elapsed += (sender, e) =>
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    UpdateStatus();    
                });
            };

            timer.Start();
            timer.AutoReset = true;
        }

        private void ExportCSV(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(
                    string.Join(", ", new string[] {
                        "Date",
                        "Description",
                        "Principal",
                        "InterestRate",
                        "AccruedInterest",
                        "InterestBalance",
                        "InterestPaid",
                        "PrincipalBalance",
                        "PrincipalPaid",
                        "TotalOwed"
                    }
                ));

                foreach (Balance record in BalanceData)
                {
                    Transaction trans = record.Transaction;

                    writer.WriteLine(
                        string.Join(", ", new object[] {
                            trans.RawDate.ToString("yyyy/MM/dd"),
                            trans.Description,
                            trans.Principal,
                            trans.InterestRate,
                            record.AccruedInterest,
                            record.InterestBalance,
                            record.InterestPaid,
                            record.PrincipalBalance,
                            record.PrincipalPaid,
                            record.TotalOwed
                        }
                    ));
                }
            }

            MessageBox.Show("Exported data successfully.");
        }

        private void PrintPDF()
        {
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Installed package";

            PdfPage page = pdf.AddPage();

            XGraphics graphic = XGraphics.FromPdfPage(page);

            XFont body = new XFont("Arial", 11, XFontStyle.Regular);
            XFont subtitle = new XFont("Arial", 12, XFontStyle.Bold);
            XFont title = new XFont("Arial", 18, XFontStyle.Bold);

            int brline = 30;

            string nameTitle = $"Barcoin - {SelectedCreditor.CreditorName} {SelectedCreditor.CreditorSurname}'s transactions.";
            XSize size = graphic.MeasureString(nameTitle, title);

            graphic.DrawString(
                nameTitle,
                title,
                XBrushes.Black,
                new XRect(page.Width.Point / 2 - size.Width / 2, brline, page.Width.Point - size.Width / 2, page.Height.Point - 20),
                XStringFormats.TopLeft
            );

            foreach (Balance record in BalanceData)
            {
                Transaction t = record.Transaction;

                brline += 50;

                graphic.DrawString(
                    "Date:",
                    subtitle,
                    XBrushes.Black,
                    new XRect(40, brline, page.Width.Point - 20, page.Height.Point - 20),
                    XStringFormats.TopLeft
                );

                graphic.DrawString(
                    t.RawDate.ToString("yyyy/MM/dd"),
                    body, XBrushes.Black,
                    new XRect(80, brline, page.Width.Point - 20, page.Height.Point - 20),
                    XStringFormats.TopLeft
                );

                graphic.DrawString(
                    "Principal:",
                    subtitle,
                    XBrushes.Black,
                    new XRect(160, brline, page.Width.Point - 20, page.Height.Point - 20), XStringFormats.TopLeft
                );

                graphic.DrawString(
                    t.Principal.ToString(),
                    body, XBrushes.Black,
                    new XRect(225, brline, page.Width.Point - 20, page.Height.Point - 20),
                    XStringFormats.TopLeft
                );

                graphic.DrawString(
                    "Interest Rate:",
                    subtitle,
                    XBrushes.Black,
                    new XRect(260, brline, page.Width.Point - 20, page.Height.Point - 20), XStringFormats.TopLeft
                );

                graphic.DrawString(
                    t.InterestRate.ToString(),
                    body, XBrushes.Black,
                    new XRect(350, brline, page.Width.Point - 20, page.Height.Point - 20),
                    XStringFormats.TopLeft
                );

                if (brline >= 700)
                {
                    page = pdf.AddPage();
                    graphic = XGraphics.FromPdfPage(page);
                    brline = 30;
                }
            }

            string pdfName = $"{SelectedCreditor.CreditorName}{SelectedCreditor.CreditorSurname}-Transactions.pdf";

            try
            {
                pdf.Save($"./PDFTransactions/{pdfName}");
            }
            catch (IOException)
            {
                MessageBox.Show("Error while printing the PDF, you may have it open and Barcoin can't access it.");
            }

            MessageBox.Show("Printed PDF successfully.");
        }

        private void UpdateStatus()
        {
            Transactions = new ObservableCollection<Transaction>(
                //RepoTransactions.Get(SelectedCreditor.CreditLineID)
            );
            BalanceData = new ObservableCollection<Balance>();

            Dates = new List<string>();
            TotalOwedKeypoints = new List<double>();
            PrincipalKeypoints = new List<double>();

            CalculateBalance();

            GraphData = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double>(TotalOwedKeypoints),
                    Title = "Total Owed"
                },

                new ColumnSeries
                {
                    Values = new ChartValues<double>(PrincipalKeypoints),
                    Title = "Principal"
                }
            };
        }

        private void CalculateBalance()
        {
            double principalBalance = 0;
            double interestBalance = 0;
            double totalOwed = 0;

            List<double> lastDailyInterests = new List<double>();
            List<DateTime> lastDrawDates = new List<DateTime>();

            for (int l = 0; l < Transactions.Count; l++)
            {
                Transaction t = Transactions[l];

                int draw = t.Principal;

                double interestRate = t.InterestRate;
                int diemRate = SelectedCreditor.DiemRate;

                DateTime currentDrawDate = t.RawDate;
                DateTime lastDrawDate = l == 0 ? currentDrawDate.AddDays(-1) : Transactions[l-1].RawDate;

                double accruedInterest = draw >= 0 ? draw * (interestRate / 100 / diemRate) : 0;
                double interestPaid = 0;
                double principalPaid = 0;

                for (int i = 0; i < lastDailyInterests.Count; i++)
                {
                    accruedInterest += lastDailyInterests[i] * (currentDrawDate - lastDrawDates[i]).Days;
                }

                interestBalance += accruedInterest;

                if (draw < 0)
                {
                    double drawRest = 0;

                    if (interestBalance + draw <= 0)
                    {
                        drawRest = draw + interestBalance;
                        interestBalance = 0;

                        principalBalance += drawRest;
                        totalOwed = principalBalance;

                        interestPaid = drawRest - draw;
                        principalPaid = -drawRest;
                    }
                    else
                    {
                        interestBalance += draw;
                        interestPaid = -draw;
                    }
                }
                else
                {
                    principalBalance += draw;
                    totalOwed += draw + accruedInterest;
                }

                lastDailyInterests.Add(draw * (interestRate / 100.0 / diemRate));
                lastDrawDates.Add(lastDrawDate);

                Dates.Add(string.Format("{0:yyyy/MM/dd}", t.RawDate));
                TotalOwedKeypoints.Add(Math.Round(totalOwed, 3));
                PrincipalKeypoints.Add(t.Principal);

                Balance b = new Balance()
                {
                    Transaction = t,
                    PrincipalBalance = Math.Round(principalBalance, 3),
                    AccruedInterest = Math.Round(accruedInterest, 3),
                    InterestBalance = Math.Round(interestBalance, 3),
                    InterestPaid = Math.Round(interestPaid, 3),
                    PrincipalPaid = Math.Round(principalPaid, 3),
                    TotalOwed = Math.Round(totalOwed, 3)
                };

                BalanceData.Add(b);
            }
        }
    }
}
