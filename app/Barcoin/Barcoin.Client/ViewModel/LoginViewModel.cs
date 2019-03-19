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
    public class LoginViewModel : BindableBase
    {
        private readonly IDialogCoordinator dialogCoordinator;

        public IDelegateCommand GotoRegisterCommand { get; private set; }
        public IDelegateCommand LoginCommand { get; private set; }

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

            userRepo = new UserRepository();
        }

        private void OnGotoRegister(object obj)
        {
            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Register;
        }

        private void OnLogin(object obj)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                Error = "Enter a username.";
                ErrorVisibility = Visibility.Visible;
                return;
            }

            User user = userRepo.Get(Username);

            if(user != null)
            {
                PasswordBox passwordBox = obj as PasswordBox;
                string password = passwordBox.Password;

                var passwordHash = HashUtils.ComputeHashSha256(
                    Encoding.UTF8.GetBytes(
                        password +
                        user.Salt
                    )
                );

                password = string.Empty;

                if (Convert.ToBase64String(passwordHash).Equals(user.Password))
                {
                    dialogCoordinator.ShowMessageAsync(
                        this,
                        "Login Successful",
                        "You are now signed into your profile."
                    );

                    ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Dashboard;

                    Application.Current.Resources["SID"] = user.Id;

                    Messenger.Default.Send(user);
                }
                else
                {
                    dialogCoordinator.ShowMessageAsync(
                        this,
                        "Login Failed",
                        "The credentials you provided are invalid. Please double check and retry."
                    );
                }
            }
            else
            {
                dialogCoordinator.ShowMessageAsync(
                    this,
                    "Login Failed",
                    "The credentials you provided are invalid. Please double check and retry."
                );
            }
        }

        private bool CanLogin(object obj)
        {
            return true;
        }
    }
}
