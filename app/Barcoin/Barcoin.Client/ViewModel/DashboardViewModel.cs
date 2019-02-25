using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using Barcoin.Client.Model;
using Barcoin.Client.Service;
using MVVM;
using System.Collections.ObjectModel;
using System.Linq;

namespace Barcoin.Client.ViewModel
{
    public class DashboardViewModel : BindableBase
    {
        public IDelegateCommand SignoutCommand { get; private set; }

        private User SignedUser { get; set; }

        private ObservableCollection<Transaction> Transactions { get; set; }

        public ObservableCollection<CustomTransaction> CustomTransactions { get; set; }

        public ChartSeriesRepository ChartSeriesRepo { get; set; }

        public string Fullname { get; set; }

        public string Balance { get; set; }

        public DashboardViewModel()
        {
            SignoutCommand = new DelegateCommand(OnSignout);

            Messenger.Default.Register<User>(this, OnSentUser);
        }

        private void OnSentUser(User user)
        {
            SignedUser = user;

            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            DigitalSignatureUtils.AssignOrRetrieveKeyPair(SignedUser.Address);

            var barcoin = new Blockchain.Model.Blockchain();

            Transactions = barcoin.GetUserRelevantTransactions(SignedUser.Id);
            Transactions.OrderBy(x => x.Timestamp.TimeOfDay);

            CustomTransactions = new ObservableCollection<CustomTransaction>();

            ChartSeriesRepo = new ChartSeriesRepository(barcoin.GetTransactions());

            Fullname = SignedUser.Firstname + " " + SignedUser.Lastname;

            float balance = 0.0f;

            foreach (Transaction t in Transactions)
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

            Balance = balance.ToString("n5");
        }

        private void OnSignout(object obj)
        {
            SignedUser = null;

            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Login;
        }
    }
}
