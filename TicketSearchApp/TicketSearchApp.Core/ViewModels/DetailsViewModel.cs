using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSearchApp.Core.Models;
using TicketSearchApp.Core.Services;

namespace TicketSearchApp.Core.ViewModels
{
    public class DetailsViewModel : MvxViewModel<AirportModel>
    {
        private readonly IAirportService _airportService;

        public DetailsViewModel(IAirportService airportService, IMvxNavigationService navigationService)
        {
            _airportService = airportService;
        }

        private AirportModel _airport;
        public AirportModel Airport
        {
            get => _airport;
            set => SetProperty(ref _airport, value);
        }

        private List<FlightInfoModel> _flights;
        public List<FlightInfoModel> Flights
        {
            get => _flights;
            set => SetProperty(ref _flights, value);
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private bool _isResultVisible;
        public bool IsResultVisible
        {
            get => _isResultVisible;
            set => SetProperty(ref _isResultVisible, value);
        }

        private bool _isEmptyVisible;
        public bool IsEmptyVisible
        {
            get => _isEmptyVisible;
            set => SetProperty(ref _isEmptyVisible, value);
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            await GetFlightsCommand.ExecuteAsync();
        }

        public IMvxAsyncCommand GetFlightsCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    IsLoading = true;
                    IsResultVisible = false;
                    IsEmptyVisible = false;
                    await Task.Delay(5000);
                    Flights = await _airportService.GetFlightsList(Airport.OriginIata, Airport.DestinyIata, Airport.Date);
                    IsLoading = false;
                    IsEmptyVisible = Flights == null || !Flights.Any();
                    IsResultVisible = Flights != null && Flights.Any();
                });
            }
        }

        public override void Prepare(AirportModel parameter)
        {
            Airport = parameter;
        }
    }
}
