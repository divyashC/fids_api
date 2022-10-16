using System;
using System.Collections.Generic;

namespace fids_api.Models
{
    public partial class FlightDetail
    {
        public int FlightId { get; set; }
        public string FlightNo { get; set; } = null!;
        public string Airline { get; set; } = null!;
        public string Origin { get; set; } = null!;
        public string OriginIata { get; set; } = null!;
        public TimeSpan DepartureTime { get; set; }
        public int DepartureTerminal { get; set; }
        public string Destination { get; set; } = null!;
        public string DestinationIata { get; set; } = null!;
        public TimeSpan ArrivalTime { get; set; }
        public int ArrivalTerminal { get; set; }
        public DateTime FlightDate { get; set; }
        public string FlightDuration { get; set; } = null!;
    }
}
