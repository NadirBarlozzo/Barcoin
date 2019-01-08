using Launcher.Static;
using System.Windows;

namespace Launcher
{
    public partial class MainWindow : Window
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

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
