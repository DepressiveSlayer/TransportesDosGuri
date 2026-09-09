namespace TransportesDosGuri.Core.Domain.Entities
{
    public class Aircraft
    {
        public long Id { get; set; }

        public AircraftType Type { get; set; }

        public string? Model { get; set; }

    }

    public enum AircraftType
    {
        Unspecified = 0,

        CommercialAircraft,

        BusinessAircraft,

        CargoAircraft,

        RegionalAircraft,

        Jet
    }
}
