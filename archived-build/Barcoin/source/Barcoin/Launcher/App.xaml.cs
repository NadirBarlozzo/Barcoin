using System;
using System.Configuration;
using System.Windows;
using Launcher.Enum;
using Launcher.Static;

namespace Launcher
{
    public partial class App : Application
    {
        public App()
        {
            string value = ConfigurationManager.AppSettings["modality"].ToLower();

            if (value.Equals("online"))
            {
                Settings.Mode = Modality.Online;
            }
            else if(value.Equals("local"))
            {
                Settings.Mode = Modality.Local;
            }
            else
            {
                MessageBox.Show("Modality setting in application config is invalid, should be either 'online' or 'local'.");
                Shutdown();
            }
        }
    }
}
