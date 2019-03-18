using MahApps.Metro.Controls.Dialogs;
using MVVM;
using System;
using System.Windows;

namespace Barcoin.Client.ViewModel
{
    public class SendViewModel : BindableBase
    {
        private readonly IDialogCoordinator dialogCoordinator;

        public IDelegateCommand GotoDashboardCommand { get; private set; }
        public IDelegateCommand SendCommand { get; private set; }

        private string error;

        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }

        private Visibility errorVisibility = Visibility.Hidden;

        public Visibility ErrorVisibility
        {
            get { return errorVisibility; }
            set { SetProperty(ref errorVisibility, value); }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                SetProperty(ref address, value);
                ErrorVisibility = Visibility.Hidden;
            }
        }

        private string amount;

        public string Amount
        {
            get { return amount; }
            set
            {
                SetProperty(ref amount, value);
                ErrorVisibility = Visibility.Hidden;
            }
        }

        private bool isLegal;

        public bool IsLegal
        {
            get { return isLegal; }
            set
            {
                SetProperty(ref isLegal, value);
                ErrorVisibility = Visibility.Hidden;
            }
        }

        public SendViewModel()
        {
            dialogCoordinator = DialogCoordinator.Instance;

            GotoDashboardCommand = new DelegateCommand(OnGotoDashboard);
            SendCommand = new DelegateCommand(OnSend, CanSend);
        }

        private bool CanSend(object arg)
        {
            return true;
        }

        private void OnSend(object obj)
        {
            if (string.IsNullOrWhiteSpace(Address))
            {
                Error = "Enter a receiver's address.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            if (string.IsNullOrWhiteSpace(Amount))
            {
                Error = "Enter an amount to be sent.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            if (!IsLegal)
            {
                Error = "Accept our terms and services.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            var barcoin = new Blockchain.Model.Blockchain();

            int recipientId = barcoin.GetIdFromAddress(Address);

            barcoin.AcceptBlock(
                barcoin.GenerateBlock(
                    (int)Application.Current.Resources["SID"],
                    recipientId,
                    float.Parse(Amount)
                )
            );

            dialogCoordinator.ShowMessageAsync(
                this,
                "Transaction Successful",
                "Find furthermore information about your transactions in the dashboard tab."
            );

            Address = string.Empty;
            Amount = string.Empty;
        }

        private void OnGotoDashboard(object obj)
        {
            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Dashboard;

            ViewModelLocator.Dashboard.InitializeDashboard();
        }
    }
}
