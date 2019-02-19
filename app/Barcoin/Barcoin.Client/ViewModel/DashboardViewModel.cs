using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using MVVM;
using System.Collections.ObjectModel;

namespace Barcoin.Client.ViewModel
{
    public class DashboardViewModel : BindableBase
    {
        public IDelegateCommand SignoutCommand { get; private set; }

        public User SignedUser { get; set; }

        public ObservableCollection<Transaction> Transactions { get; set; }

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
