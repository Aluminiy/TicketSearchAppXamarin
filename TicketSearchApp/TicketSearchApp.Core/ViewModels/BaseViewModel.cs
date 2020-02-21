using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSearchApp.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        public IMvxNavigationService NavigationService { get; }

        public BaseViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
