using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher.Static
{
    public static class Splasher
    {
        public static Window Splash { get; set; }

        public static void ShowSplash()
        {
            if (Splash != null)
            {
                Splash.Show();
            }
        }

        public static void CloseSplash()
        {
            if (Splash != null)
            {
                Splash.Close();

                if (Splash is IDisposable)
                {
                    (Splash as IDisposable).Dispose();
                }
            }
        }

    }
}
