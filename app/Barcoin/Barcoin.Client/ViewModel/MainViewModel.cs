using MVVM;

namespace Barcoin.Client.ViewModel
{
    public class MainViewModel : BindableBase
    {
        public IDelegateCommand DashboardCommand { get; private set; }
        public IDelegateCommand AboutCommand { get; private set; }

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
            CurrentViewModel = ViewModelLocator.Login;
        }

        private void RegisterCommands()
        {
            DashboardCommand = new DelegateCommand(OnDashboard);
            AboutCommand = new DelegateCommand(OnAbout);
        }

        private void OnAbout(object obj)
        {
            CurrentViewModel = ViewModelLocator.About;
        }

        private void OnDashboard(object obj)
        {
            CurrentViewModel = ViewModelLocator.Dashboard;
        }
    }
}
