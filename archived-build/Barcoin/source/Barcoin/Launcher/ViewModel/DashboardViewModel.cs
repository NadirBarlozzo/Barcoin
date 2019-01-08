using Launcher.Model;
using Launcher.Service;
using MVVM;
using System.Collections.ObjectModel;

namespace Launcher.ViewModel
{
    public class DashboardViewModel : BindableBase
    {
        public IDelegateCommand DetailCommand { get; private set; }

        public ObservableCollection<Creditor> Creditors { get; set; }

        public DashboardViewModel()
        {
            CreditorDataRepository repo = new CreditorDataRepository();

            Creditors = new ObservableCollection<Creditor>(repo.Get());

            DetailCommand = new DelegateCommand(OnDetail);
        }

        private void OnDetail(object obj)
        {
            Messenger.Default.Send((Creditor)obj);
        }
    }
}
