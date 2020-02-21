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
using Xamarin.Forms.Maps;

namespace TicketSearchApp.Core.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly IAirportService _airportService;

        public SearchViewModel(IAirportService airportService, IMvxNavigationService navigationService) : base(navigationService)
        {
            _airportService = airportService;
        }

        private string _iata;
        public string Iata
        {
            get => _iata;
            set => SetProperty(ref _iata, value);
        }

        private DateTime _dateTime;
        public DateTime DateTime
        {
            get => _dateTime;
            set => SetProperty(ref _dateTime, value);
        }

        private List<AirportInfoModel> _airports;
        public List<AirportInfoModel> Airports
        {
            get => _airports;
            set => SetProperty(ref _airports, value);
        }

        private List<Pin> _pins;
        public List<Pin> Pins
        {
            get => _pins;
            set => SetProperty(ref _pins, value);
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

        public IMvxAsyncCommand SearchCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    IsLoading = true;
                    IsResultVisible = false;
                    IsEmptyVisible = false;
                    await Task.Delay(5000);
                    Airports = await _airportService.GetAirportsList(Iata.ToUpper());
                    Pins = Airports?.Where(c => c.Coordinates[0].HasValue).Select(a => new Pin 
                    {
                        Position = new Position(a.Coordinates[0].Value, a.Coordinates[1].Value),
                        Label = a.Name
                    }).ToList();
                    IsLoading = false;
                    IsEmptyVisible = Airports == null || !Airports.Any();
                    IsResultVisible = Airports != null && Airports.Any();
                });
            }
        }

        public override Task Initialize()
        {
            DateTime = DateTime.UtcNow;
            return base.Initialize();
        }

    }
}
