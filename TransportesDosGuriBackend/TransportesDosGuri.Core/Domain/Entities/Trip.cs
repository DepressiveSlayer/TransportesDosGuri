namespace TransportesDosGuri.Core.Domain.Entities
{
    public class Trip
    {
        public long Id { get; set; }

        public string? TripName { get; set; }

        public long OriginAirportId { get; set; }

        public long DestinyAirportId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
