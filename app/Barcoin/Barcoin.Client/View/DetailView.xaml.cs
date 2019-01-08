using System.Windows.Controls;
using System.Windows.Input;

namespace Barcoin.Client.View
{
    /// <summary>
    /// Logica di interazione per DetailView.xaml
    /// </summary>
    public partial class DetailView : UserControl
    {
        public DetailView()
        {
            InitializeComponent();
            Focusable = true;
            Loaded += (s, e) => Keyboard.Focus(this);
        }
    }
}
