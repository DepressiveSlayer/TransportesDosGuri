using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<TripDTO> CreateAsync(TripDTO trip)
        {
            var tripEntity = new Trip
            {
                TripName = trip.TripName,
                OriginAirportId = trip.OriginAirportId,
                DestinyAirportId = trip.DestinyAirportId,
                DepartureTime = trip.DepartureTime,
                ArrivalTime = trip.ArrivalTime,
                TotalPrice = trip.TotalPrice
            };

            await _tripRepository.AddAsync(tripEntity);

            trip.Id = tripEntity.Id;

            return trip;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var tripEntity = await _tripRepository.GetByIdAsync(id);

            if (tripEntity == null)
            {
                return false;
            }

            await _tripRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<TripDTO>> GetAllAsync()
        {
            var tripEntities = await _tripRepository.GetAllAsync();

            return tripEntities.Select(tripEntities => new TripDTO
            {
                Id = tripEntities.Id,
                OriginAirportId = tripEntities.OriginAirportId,
                DestinyAirportId = tripEntities.DestinyAirportId,
                DepartureTime = tripEntities.DepartureTime,
                ArrivalTime = tripEntities.ArrivalTime,
                TotalPrice = tripEntities.TotalPrice
            });

        }

        public async Task<TripDTO?> GetByIdAsync(long id)
        {
            var tripEntity = await _tripRepository.GetByIdAsync(id);

            if (tripEntity == null)
            {
                return null;
            }

            return new TripDTO
            {
                Id = tripEntity.Id,
                OriginAirportId = tripEntity.OriginAirportId,
                DestinyAirportId = tripEntity.DestinyAirportId,
                DepartureTime = tripEntity.DepartureTime,
                ArrivalTime = tripEntity.ArrivalTime,
                TotalPrice = tripEntity.TotalPrice
            };
        }

        public async Task<bool> UpdateAsync(long id, TripDTO trip)
        {
            var existingTrip = await _tripRepository.GetByIdAsync(id);

            if (existingTrip == null)
            {
                return false;
            }

            existingTrip.OriginAirportId = trip.OriginAirportId;
            existingTrip.DestinyAirportId = trip.DestinyAirportId;
            existingTrip.DepartureTime = trip.DepartureTime;
            existingTrip.ArrivalTime = trip.ArrivalTime;
            existingTrip.TotalPrice = trip.TotalPrice;

            await _tripRepository.UpdateAsync(existingTrip);

            return true;
        }
    }
}
