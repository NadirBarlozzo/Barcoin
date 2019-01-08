using System;
using System.Windows;

namespace Barcoin.Client.Static
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
