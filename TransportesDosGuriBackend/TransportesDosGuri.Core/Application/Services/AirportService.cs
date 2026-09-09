using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<AirportDTO> CreateAsync(AirportDTO airport)
        {
            var airportEntity = new Airport
            {
                Name = airport.Name,
                City = airport.City,
                State = airport.State,
                Country = airport.Country
            };

            await _airportRepository.AddAsync(airportEntity);

            airport.Id = airportEntity.Id;

            return airport;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var airportEntity = await _airportRepository.GetByIdAsync(id);

            if (airportEntity == null)
            {
                return false;
            }

            await _airportRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<AirportDTO>> GetAllAsync()
        {
            var airportEntities = await _airportRepository.GetAllAsync();

            return airportEntities.Select(airportEntities => new AirportDTO
            {
                Id = airportEntities.Id,
                Name = airportEntities.Name,
                City = airportEntities.City,
                State = airportEntities.State,
                Country = airportEntities.Country
            });
        }

        public async Task<AirportDTO?> GetByIdAsync(long id)
        {
            var airportEntity = await _airportRepository.GetByIdAsync(id);

            if (airportEntity == null)
            {
                return null;
            }

            return new AirportDTO
            {
                Id = airportEntity.Id,
                Name = airportEntity.Name,
                City = airportEntity.City,
                State = airportEntity.State,
                Country = airportEntity.Country
            };
        }

        public async Task<bool> UpdateAsync(long id, AirportDTO airport)
        {
            var existingAirport = await _airportRepository.GetByIdAsync(id);

            if (existingAirport == null)
            {
                return false;
            }

            existingAirport.Name = airport.Name;
            existingAirport.City = airport.City;
            existingAirport.State = airport.State;
            existingAirport.Country = airport.Country;

            await _airportRepository.UpdateAsync(existingAirport);

            return true;
        }
    }
}
