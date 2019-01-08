using MVVM;

namespace Launcher.ViewModel
{
    public class AboutViewModel : BindableBase
    {
        public IDelegateCommand VideoCommand { get; private set; }

        public string Description { get; set; }

        public AboutViewModel()
        {
            VideoCommand = new DelegateCommand(OnVideo);

            Description = "As the demand for micro-credits financial management systems, in poor or financially unstable" +
                " countries, increases every day, new software solutions have to rise in order to prevent frauds and secure these" +
                " transactions. Barcoin aims to be a budget solution for this problem in a rather small environment.";
        }

        private void OnVideo(object obj)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=bpSNM625LFU");
        }
    }
}
