using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSearchApp.Core.Models.ResponseModels
{
    public class DirectionsResponse
    {
        [JsonProperty("directions")]
        public List<AirportInfoModel> Airports { get; set; }
    }
}
