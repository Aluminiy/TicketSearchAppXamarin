using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketSearchApp.Core.Models;

namespace TicketSearchApp.Core.Services
{
    public class AirportService : IAirportService
    {
        private readonly IClientService _clientService;

        public AirportService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<List<AirportInfoModel>> GetAirportsList(string iata)
        {
            return await _clientService.GetAirportsList(iata);
        }

        public async Task<List<FlightInfoModel>> GetFlightsList(string originIata, string destinyIata, string date)
        {
            return await _clientService.GetFlightsList(originIata, destinyIata, date);
        }
    }
}
