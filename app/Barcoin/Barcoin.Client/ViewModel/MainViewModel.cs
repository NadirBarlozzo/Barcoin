using MVVM;
using System;
using System.Windows;

namespace Barcoin.Client.ViewModel
{
    public class MainViewModel : BindableBase
    {
        public IDelegateCommand DashboardCommand { get; private set; }
        public IDelegateCommand SettingsCommand { get; private set; }
        public IDelegateCommand AboutCommand { get; private set; }

        private string syncState;

        public string SyncState
        {
            get { return syncState; }
            set { SetProperty(ref syncState, value); }
        }

        private BindableBase currentViewModelBase;

        public BindableBase CurrentViewModel
        {
            get { return currentViewModelBase; }
            set
            {
                SetProperty(ref currentViewModelBase, value);
            }
        }

        public MainViewModel()
        {
            RegisterCommands();

            SyncState = "login required";

            CurrentViewModel = ViewModelLocator.Login;
        }

        private void RegisterCommands()
        {
            DashboardCommand = new DelegateCommand(OnDashboard);
            SettingsCommand = new DelegateCommand(OnSettings);
            AboutCommand = new DelegateCommand(OnAbout);
        }

        private void OnSettings(object obj)
        {
            //settings vm
        }

        private void OnAbout(object obj)
        {
            CurrentViewModel = ViewModelLocator.About;
        }

        private void OnDashboard(object obj)
        {
            if (Application.Current.Resources["SID"] != null)
            {
                CurrentViewModel = ViewModelLocator.Dashboard;
            }
            else
            {
                CurrentViewModel = ViewModelLocator.Login;
            }
        }
    }
}
