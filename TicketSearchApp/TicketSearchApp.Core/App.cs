using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TicketSearchApp.Core.Services;
using TicketSearchApp.Core.ViewModels;

namespace TicketSearchApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            Mvx.IoCProvider.RegisterType<IClientService, ClientService>();
            Mvx.IoCProvider.RegisterType<IAirportService, AirportService>();

            RegisterAppStart<SearchViewModel>();
        }
    }
}
