using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSearchApp.Core.Models
{
    public class FlightInfoModel
    {
        [JsonProperty("return_date")]
        public string ReturnDate { get; set; }

        [JsonProperty("depart_date")]
        public string DepartDate { get; set; }

        [JsonProperty("value")]
        public double Price { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }
    }
}
