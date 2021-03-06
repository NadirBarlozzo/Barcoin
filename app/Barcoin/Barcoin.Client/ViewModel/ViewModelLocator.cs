﻿using CommonServiceLocator;
using MVVM;

namespace Barcoin.Client.ViewModel
{
    public class ViewModelLocator
    {
        public static MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public static DashboardViewModel Dashboard
        {
            get { return ServiceLocator.Current.GetInstance<DashboardViewModel>(); }
        }

        public static AboutViewModel About
        {
            get { return ServiceLocator.Current.GetInstance<AboutViewModel>(); }
        }

        public static LoginViewModel Login
        {
            get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); }
        }

        public static RegisterViewModel Register
        {
            get { return ServiceLocator.Current.GetInstance<RegisterViewModel>(); }
        }

        public static SendViewModel Send
        {
            get { return ServiceLocator.Current.GetInstance<SendViewModel>(); }
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<DashboardViewModel>();
            SimpleIoc.Default.Register<SendViewModel>();
        }
    }
}
