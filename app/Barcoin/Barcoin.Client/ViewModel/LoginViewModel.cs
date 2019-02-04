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
    public class LoginViewModel : BindableBase
    {
        public IDelegateCommand GotoRegisterCommand { get; private set; }
        public IDelegateCommand LoginCommand { get; private set; }

        private UserDataRepository userRepo;

        private string error;

        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }


        private string username;

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        public LoginViewModel()
        {
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
                return;
            }

            User current = userRepo.Get(Username);

            if(current == null)
            {
                Error = "Invalid credentials, double check your username and password.";
                return;
            }

            PasswordBox passwordBox = obj as PasswordBox;
            string password = passwordBox.Password;

            var passwordHash = Hash.ComputeHashSha256(
                Encoding.UTF8.GetBytes(
                    password +
                    current.Salt
                )
            );

            password = string.Empty;

            if(Convert.ToBase64String(passwordHash).Equals(current.Password))
            {
                MessageBox.Show("Successful login");
            }
        }

        private bool CanLogin(object obj)
        {
            return true;
        }
    }
}
