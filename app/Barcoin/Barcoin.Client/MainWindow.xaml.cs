using Barcoin.Client.Static;
using Barcoin.Client.ViewModel;
using MVVM;
using System.Windows;

namespace Barcoin.Client
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            Splasher.Splash = new SplashScreenWindow();
            Splasher.ShowSplash();
            Loaded += MainWindow_Loaded;

            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Splasher.CloseSplash();
        }
    }
}
