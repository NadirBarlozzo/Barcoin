using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using Barcoin.Client.Model;
using Barcoin.Client.Service;
using MVVM;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Barcoin.Client.ViewModel
{
    public class DashboardViewModel : BindableBase
    {
        public IDelegateCommand SignoutCommand { get; private set; }
        public IDelegateCommand GotoSendCommand { get; private set; }

        private User SignedUser { get; set; }

        public ObservableCollection<CustomTransaction> CustomTransactions { get; set; }

        public ChartSeriesRepository ChartSeriesRepo { get; set; }

        public string Fullname { get; set; }

        public string Balance { get; set; }

        public DashboardViewModel()
        {
            SignoutCommand = new DelegateCommand(OnSignout);
            GotoSendCommand = new DelegateCommand(OnGotoSend);

            Messenger.Default.Register<User>(this, OnSentUser);
        }

        private void OnGotoSend(object obj)
        {
            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Send;
        }

        private void OnSentUser(User user)
        {
            SignedUser = user;

            InitializeDashboard();
        }

        public void InitializeDashboard()
        {
            DigitalSignatureUtils.RetrieveKeyPair(SignedUser.Address);

            var barcoin = new Blockchain.Model.Blockchain();

            ObservableCollection<Transaction> transactions = barcoin.GetUserRelevantTransactions(SignedUser.Id);

            var orderedTransactions = transactions.OrderByDescending(x => x.Timestamp.Date)
                .ThenByDescending(x => x.Timestamp.TimeOfDay);

            CustomTransactions = new ObservableCollection<CustomTransaction>();

            Fullname = SignedUser.Firstname + " " + SignedUser.Lastname;

            float balance = 0.0f;

            foreach (Transaction t in orderedTransactions)
            {
                if (t.RecipientId == SignedUser.Id)
                {
                    balance += t.Amount;
                }
                else
                {
                    balance -= t.Amount;
                }

                string sender = barcoin.GetUsernameById(t.SenderId);
                string recipient = barcoin.GetUsernameById(t.RecipientId);

                CustomTransaction ct = new CustomTransaction()
                {
                    Id = t.Id,
                    Hash = t.ComputeHash(),
                    Sender = t.SenderId == SignedUser.Id ? "You" : sender,
                    Recipient = t.RecipientId == SignedUser.Id ? "You" : recipient,
                    Amount = t.Amount,
                    Timestamp = t.Timestamp.ToString("yyyy.MM.dd"),
                    Color = t.RecipientId == SignedUser.Id ? "DeepSkyBlue" : "Transparent"
                };

                CustomTransactions.Add(ct);
            }

            ChartSeriesRepo = new ChartSeriesRepository(
                barcoin.GetTransactions()
                .OrderByDescending(x => x.Timestamp.Date)
                .Take(50),
                CustomTransactions
            );

            Balance = balance.ToString("n4");

            if(barcoin.IsValid())
            {
                ViewModelLocator.Main.SyncState = "up to date";
            }
            else
            {
                ViewModelLocator.Main.SyncState = "out of sync";
            }
        }

        private void OnSignout(object obj)
        {
            SignedUser = null;

            Application.Current.Resources["SID"] = null;

            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Login;
        }
    }
}
