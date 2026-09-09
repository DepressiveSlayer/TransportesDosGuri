using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<SeatDTO> CreateAsync(SeatDTO seat)
        {
            var seatEntity = new Seat
            {
                AircraftId = seat.AircraftId,
                SeatNumber = seat.SeatNumber,
                Class = seat.Class,
                Location = seat.Location,
                Side = seat.Side
            };

            await _seatRepository.AddAsync(seatEntity);

            seat.Id = seatEntity.Id;

            return seat;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var seatEntity = await _seatRepository.GetByIdAsync(id);

            if (seatEntity == null)
            {
                return false;
            }

            await _seatRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<SeatDTO>> GetAllAsync()
        {
            var seatEntities = await _seatRepository.GetAllAsync();

            return seatEntities.Select(seatEntities => new SeatDTO
            {
                Id = seatEntities.Id,
                AircraftId = seatEntities.AircraftId,
                SeatNumber = seatEntities.SeatNumber,
                Class = seatEntities.Class,
                Location = seatEntities.Location,
                Side = seatEntities.Side
            });
        }

        public async Task<SeatDTO?> GetByIdAsync(long id)
        {
            var seatEntity = await _seatRepository.GetByIdAsync(id);

            if (seatEntity == null)
            {
                return null;
            }

            return new SeatDTO
            {
                Id = seatEntity.Id,
                AircraftId = seatEntity.AircraftId,
                SeatNumber = seatEntity.SeatNumber,
                Class = seatEntity.Class,
                Location = seatEntity.Location,
                Side = seatEntity.Side
            };
        }

        public async Task<bool> UpdateAsync(long id, SeatDTO seat)
        {
            var existingSeat = await _seatRepository.GetByIdAsync(id);

            if (existingSeat == null)
            {
                return false;
            }

            existingSeat.AircraftId = seat.AircraftId;
            existingSeat.SeatNumber = seat.SeatNumber;
            existingSeat.Class = seat.Class;
            existingSeat.Location = seat.Location;
            existingSeat.Side = seat.Side;

            await _seatRepository.UpdateAsync(existingSeat);

            return true;
        }
    }
}
