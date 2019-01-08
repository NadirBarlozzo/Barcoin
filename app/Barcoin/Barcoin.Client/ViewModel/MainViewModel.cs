using MVVM;

namespace Barcoin.Client.ViewModel
{
    public class MainViewModel : BindableBase
    {
        public IDelegateCommand DashboardCommand { get; private set; }
        public IDelegateCommand AddCommand { get; private set; }
        public IDelegateCommand AboutCommand { get; private set; }

        public string Logo
        {
            get { return @"\Resource\logo.png"; }
        }

        public string Add
        {
            get { return @"\Resource\add.png"; }
        }

        public string About
        {
            get { return @"\Resource\guide.png"; }
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
            CurrentViewModel = ViewModelLocator.Dashboard;
        }

        private void RegisterCommands()
        {
            DashboardCommand = new DelegateCommand(OnDashboard);
            AddCommand = new DelegateCommand(OnAdd);
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

        private void OnAdd(object obj)
        {
            CurrentViewModel = ViewModelLocator.Add;
        }
    }
}
