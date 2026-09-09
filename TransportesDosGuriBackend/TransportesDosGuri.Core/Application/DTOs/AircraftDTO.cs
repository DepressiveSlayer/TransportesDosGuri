using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Application.DTOs
{
    public class AircraftDTO
    {
        public long Id { get; set; }

        public AircraftType Type { get; set; }

        public string? Model { get; set; }
    }
}
