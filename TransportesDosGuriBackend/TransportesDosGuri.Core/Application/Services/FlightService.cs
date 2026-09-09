using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<FlightDTO> CreateAsync(FlightDTO flight)
        {
            var flightEntity = new Flight
            {
                AircraftId = flight.AircraftId,
                OriginAirportId = flight.OriginAirportId,
                DestinyAirportId = flight.DestinyAirportId,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                BasePrice = flight.BasePrice,
                TripId = flight.TripId
            };

            await _flightRepository.AddAsync(flightEntity);

            flight.Id = flightEntity.Id;

            return flight;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var flightEntity = await _flightRepository.GetByIdAsync(id);

            if (flightEntity == null)
            {
                return false;
            }

            await _flightRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<FlightDTO>> GetAllAsync()
        {
            var flightEntities = await _flightRepository.GetAllAsync();

            return flightEntities.Select(flightEntities => new FlightDTO
            {
                Id = flightEntities.Id,
                AircraftId = flightEntities.AircraftId,
                OriginAirportId = flightEntities.OriginAirportId,
                DestinyAirportId = flightEntities.DestinyAirportId,
                DepartureTime = flightEntities.DepartureTime,
                ArrivalTime = flightEntities.ArrivalTime,
                BasePrice = flightEntities.BasePrice,
                TripId = flightEntities.TripId
            });
        }

        public async Task<FlightDTO?> GetByIdAsync(long id)
        {
            var flightEntity = await _flightRepository.GetByIdAsync(id);

            if (flightEntity == null)
            {
                return null;
            }

            return new FlightDTO
            {
                Id = flightEntity.Id,
                AircraftId = flightEntity.AircraftId,
                OriginAirportId = flightEntity.OriginAirportId,
                DestinyAirportId = flightEntity.DestinyAirportId,
                DepartureTime = flightEntity.DepartureTime,
                ArrivalTime = flightEntity.ArrivalTime,
                BasePrice = flightEntity.BasePrice,
                TripId = flightEntity.TripId
            };
        }

        public async Task<bool> UpdateAsync(long id, FlightDTO flight)
        {
            var existingFlight = await _flightRepository.GetByIdAsync(id);

            if (existingFlight == null)
            {
                return false;
            }

            existingFlight.AircraftId = flight.AircraftId;
            existingFlight.OriginAirportId = flight.OriginAirportId;
            existingFlight.DestinyAirportId = flight.DestinyAirportId;
            existingFlight.DepartureTime = flight.DepartureTime;
            existingFlight.ArrivalTime = flight.ArrivalTime;
            existingFlight.BasePrice = flight.BasePrice;
            existingFlight.TripId = flight.TripId;

            await _flightRepository.UpdateAsync(existingFlight);

            return true;
        }
    }
}
