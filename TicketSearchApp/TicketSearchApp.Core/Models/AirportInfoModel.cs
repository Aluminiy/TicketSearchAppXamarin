using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSearchApp.Core.Models
{
    public class AirportInfoModel
    {
        [JsonProperty("iata")]
        public string Iata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country_name")]
        public string Country { get; set; }

        [JsonProperty("coordinates")]
        public double?[] Coordinates { get; set; }
    }
}
