using Barcoin.Blockchain.Helper;
using Barcoin.Blockchain.Model;
using Barcoin.Blockchain.Service;
using MahApps.Metro.Controls.Dialogs;
using MVVM;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Barcoin.Client.ViewModel
{
    public class RegisterViewModel : BindableBase
    {
        private readonly IDialogCoordinator dialogCoordinator;

        public IDelegateCommand GotoLoginCommand { get; private set; }
        public IDelegateCommand RegisterCommand { get; private set; }

        private UserRepository userRepo;

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

        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { SetProperty(ref firstname, value); }
        }

        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { SetProperty(ref lastname, value); }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value);  }
        }

        public RegisterViewModel()
        {
            dialogCoordinator = DialogCoordinator.Instance;

            GotoLoginCommand = new DelegateCommand(OnGotoLogin);
            RegisterCommand = new DelegateCommand(OnRegister, CanRegister);

            userRepo = new UserRepository();
        }

        private void OnGotoLogin(object obj)
        {
            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Login;
        }

        private void OnRegister(object obj)
        {
            if (string.IsNullOrWhiteSpace(Firstname))
            {
                Error = "Enter a firstname.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            if (string.IsNullOrWhiteSpace(Lastname))
            {
                Error = "Enter a lastname.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            if (string.IsNullOrWhiteSpace(Username))
            {
                Error = "Enter a username.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            PasswordBox passwordBox = obj as PasswordBox;
            string password = passwordBox.Password;

            var salt = HashUtils.GetSalt();
            var passwordHash = HashUtils.ComputeHashSha256(
                Encoding.UTF8.GetBytes(
                    password +
                    Convert.ToBase64String(salt)
                )
            );

            password = string.Empty;

            Guid gAddress = Guid.NewGuid();

            User user = new User
            {
                Firstname = Firstname,
                Lastname = Lastname,
                Username = Username,
                Password = Convert.ToBase64String(passwordHash),
                Salt = Convert.ToBase64String(salt),
                Address = gAddress.ToString("N"),
                Timestamp = DateTime.Now
            };

            userRepo.Add(user);

            DigitalSignatureUtils.AssignKeyPair(user.Address);

            dialogCoordinator.ShowMessageAsync(
                this,
                "Register Successful",
                "Your private key has been generated and you should keep it for yourself at ALL times."
            );

            Firstname = string.Empty;
            Lastname = string.Empty;
            Username = string.Empty;

            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Login;
        }

        private bool CanRegister(object obj)
        {
            return true;
        }
    }
}
