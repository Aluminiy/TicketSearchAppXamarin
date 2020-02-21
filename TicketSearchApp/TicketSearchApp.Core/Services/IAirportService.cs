using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketSearchApp.Core.Models;

namespace TicketSearchApp.Core.Services
{
    public interface IAirportService
    {
        Task<List<AirportInfoModel>> GetAirportsList(string iata);
        Task<List<FlightInfoModel>> GetFlightsList(string originIata, string destinyIata, string date);
    }
}
