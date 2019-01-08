using System;
using System.Diagnostics;
using Launcher.Model;
using Launcher.Service;
using MVVM;

namespace Launcher.ViewModel
{
    public class AddCreditorViewModel : BindableBase
    {
        public IDelegateCommand AddCreditorCommand { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set
            {
                SetProperty(ref surname, value);
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                SetProperty(ref description, value);
            }
        }

        private string diemRate;

        public string DiemRate
        {
            get { return diemRate; }
            set
            {
                SetProperty(ref diemRate, value);
            }
        }

        private string defaultInterestRate;

        public string DefaultInterestRate
        {
            get { return defaultInterestRate; }
            set
            {
                SetProperty(ref defaultInterestRate, value);
            }
        }

        public AddCreditorViewModel()
        {
            AddCreditorCommand = new DelegateCommand(OnAdd);
        }

        private void OnAdd(object obj)
        {
            CreditorDataRepository repo = new CreditorDataRepository();

            Creditor c = new Creditor()
            {
                CreditorName = Name,
                CreditorSurname = Surname,
                Description = Description,
                DiemRate = int.Parse(DiemRate),
                DefaultInterestRate = double.Parse(DefaultInterestRate)
            };

            repo.Add(c);

            ViewModelLocator.Main.CurrentViewModel = ViewModelLocator.Dashboard;
        }
    }
}
