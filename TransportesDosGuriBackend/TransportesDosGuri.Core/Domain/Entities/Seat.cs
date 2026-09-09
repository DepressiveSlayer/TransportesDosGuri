namespace TransportesDosGuri.Core.Domain.Entities
{
    public class Seat
    {
        public long Id { get; set; }

        public long AircraftId { get; set; }

        public string? SeatNumber { get; set; }

        public SeatClass Class { get; set; }

        public SeatLocation Location { get; set; }

        public SeatSide Side { get; set; }


    }

    public enum SeatClass
    {
        Economical,

        Executive,

        First
    }

    public enum SeatLocation
    {
        Window,

        Corridor,

        Middle
    }

    public enum SeatSide
    {
        Left,

        Middle,

        Right
    }
}
