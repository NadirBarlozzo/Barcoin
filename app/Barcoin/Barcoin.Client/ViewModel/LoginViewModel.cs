using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using Barcoin.Blockchain.Service;
using MahApps.Metro.Controls.Dialogs;
using MVVM;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Barcoin.Client.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        private readonly IDialogCoordinator dialogCoordinator;

        public IDelegateCommand GotoRegisterCommand { get; private set; }
        public IDelegateCommand LoginCommand { get; private set; }

        private UserDataRepository userRepo;

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

        private string username;

        public string Username
        {
            get { return username; }
            set {
                SetProperty(ref username, value);
                ErrorVisibility = Visibility.Hidden;
            }
        }

        public LoginViewModel()
        {
            dialogCoordinator = DialogCoordinator.Instance;

            GotoRegisterCommand = new DelegateCommand(OnGotoRegister);
            LoginCommand = new DelegateCommand(OnLogin, CanLogin);

            userRepo = new UserDataRepository();
        }

        private void OnGotoRegister(object obj)
        {
            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Register;
        }

        private void OnLogin(object obj)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                Error = "Username field it's blank.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            User usr = userRepo.Get(Username);

            if(usr == null)
            {
                Error = "Invalid credentials, double check your username and password.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            PasswordBox passwordBox = obj as PasswordBox;
            string password = passwordBox.Password;

            var passwordHash = HashUtils.ComputeHashSha256(
                Encoding.UTF8.GetBytes(
                    password +
                    usr.Salt
                )
            );

            password = string.Empty;

            if(Convert.ToBase64String(passwordHash).Equals(usr.Password))
            {
                DigitalSignatureUtils.AssignOrRetrieveKeyPair(usr.Address);
                byte[] data = { 59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135 };
                var hash = HashUtils.ComputeHashSha256(data);
                var signature = Convert.FromBase64String("loNBskecmXKgr25oQEHoXuBgPcIw07WNCZfKOuQecX/TuKt3cFLwmMJRfds2W9DV05DA3qPaQS4u92OgykXNeqGIc924xJ7yxKHZ8SHdGhV/KanElYwHJ/WBOZreXEYcSR3W2ESP2jpLygdDiOq/caZS2pNL33a4a8cW5XZNJB0=");
                Debug.WriteLine(Convert.ToBase64String(signature));
                MessageBox.Show(DigitalSignatureUtils.VerifySignature(hash, signature).ToString());
            }
            else
            {
                Error = "Invalid credentials, double check your username and password.";
                ErrorVisibility = Visibility.Visible;
                return;
            }
        }

        private bool CanLogin(object obj)
        {
            return true;
        }
    }
}
