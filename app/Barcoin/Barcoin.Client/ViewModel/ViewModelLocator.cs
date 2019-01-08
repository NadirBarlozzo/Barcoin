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

        public static DetailViewModel Detail
        {
            get { return ServiceLocator.Current.GetInstance<DetailViewModel>(); }
        }

        public static AddCreditorViewModel Add
        {
            get { return ServiceLocator.Current.GetInstance<AddCreditorViewModel>(); }
        }

        public static AboutViewModel About
        {
            get { return ServiceLocator.Current.GetInstance<AboutViewModel>(); }
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DashboardViewModel>();
            SimpleIoc.Default.Register<AddCreditorViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<DetailViewModel>(true);
        }
    }
}