namespace TransportesDosGuri.Core.Domain.Entities
{
    public class Schedule
    {
        public long Id { get; set; }

        public long FlightId { get; set; }

        public long AirportId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
