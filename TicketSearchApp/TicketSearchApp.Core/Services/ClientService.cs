using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketSearchApp.Core.Models;
using TicketSearchApp.Core.Models.ResponseModels;

namespace TicketSearchApp.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<AirportInfoModel>> GetAirportsList(string iata)
        {
            var requestUrl = new Uri($"http://map.aviasales.ru/supported_directions.json?origin_iata={iata}&one_way=false&locale=en");
            using (var response = await _httpClient.GetAsync(requestUrl))
            {
                List<AirportInfoModel> res = null;
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<DirectionsResponse>(body)?.Airports;
                }
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iata">airport iata</param>
        /// <param name="date">date string in format yyyy-MM-dd</param>
        /// <returns></returns>
        public async Task<List<FlightInfoModel>> GetFlightsList(string originIata, string destinyIata, string date)
        {
            var requestUrl = new Uri($"http://map.aviasales.ru/prices.json?origin_iata={originIata}&period={date}:season&direct=true&one_way=false&price=50000&no_visa=true&schengen=true&need_visa=true&locale=en&min_trip_duration_in_days=13&max_trip_duration_in_days=15");
            using (var response = await _httpClient.GetAsync(requestUrl))
            {
                List<FlightInfoModel> res = null;
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<List<FlightInfoModel>>(body);
                }
                return res?.Where(c => c.Destination == destinyIata).ToList();
            }
        }
    }
}
