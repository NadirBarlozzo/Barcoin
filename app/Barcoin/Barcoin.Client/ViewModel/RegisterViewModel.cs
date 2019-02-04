using Barcoin.Blockchain.Cryptography;
using Barcoin.Client.Model;
using Barcoin.Client.Service;
using MVVM;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Barcoin.Client.ViewModel
{
    public class RegisterViewModel : BindableBase
    {
        public IDelegateCommand GotoLoginCommand { get; private set; }
        public IDelegateCommand RegisterCommand { get; private set; }

        private UserDataRepository userRepo;

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
            GotoLoginCommand = new DelegateCommand(OnGotoLogin);
            RegisterCommand = new DelegateCommand(OnRegister, CanRegister);

            userRepo = new UserDataRepository();
        }

        private void OnGotoLogin(object obj)
        {
            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Login;
        }

        private void OnRegister(object obj)
        {
            if (string.IsNullOrWhiteSpace(Firstname))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(Lastname))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(Username))
            {
                return;
            }

            PasswordBox passwordBox = obj as PasswordBox;
            string password = passwordBox.Password;

            var salt = Hash.GetSalt();
            var passwordHash = Hash.ComputeHashSha256(
                Encoding.UTF8.GetBytes(
                    password+
                    Convert.ToBase64String(salt)
                )
            );

            password = string.Empty;

            Guid gAddress = Guid.NewGuid();

            User current = new User
            {
                Firstname = Firstname,
                Lastname = Lastname,
                Username = Username,
                Password = Convert.ToBase64String(passwordHash),
                Salt = Convert.ToBase64String(salt),
                Address = gAddress.ToString("N"),
                Timestamp = DateTime.Now
            };

            userRepo.Add(current);
        }

        private bool CanRegister(object obj)
        {
            return true;
        }
    }
}
