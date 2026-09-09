namespace TransportesDosGuri.Core.Application.DTOs
{
    public class FlightDTO
    {
        public long Id { get; set; }

        public long AircraftId { get; set; }

        public long OriginAirportId { get; set; }

        public long DestinyAirportId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal BasePrice { get; set; }

        public long TripId { get; set; }
    }
}
