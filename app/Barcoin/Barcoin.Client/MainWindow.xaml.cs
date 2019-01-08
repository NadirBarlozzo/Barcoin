using Barcoin.Client.Static;
using System.Windows;

namespace Barcoin.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
    }
}
