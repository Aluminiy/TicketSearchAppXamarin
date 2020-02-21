using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSearchApp.Core.Models
{
    public class AirportModel
    {
        public string OriginIata { get; set; }
        public string DestinyIata { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
