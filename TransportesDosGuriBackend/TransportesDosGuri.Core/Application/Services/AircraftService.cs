using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftRepository _aircraftRepository;

        public AircraftService(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        public async Task<AircraftDTO> CreateAsync(AircraftDTO aircraft)
        {
            var aircraftEntity = new Aircraft
            {
                Type = aircraft.Type,
                Model = aircraft.Model
            };

            await _aircraftRepository.AddAsync(aircraftEntity);

            aircraft.Id = aircraftEntity.Id;

            return aircraft;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var aircraftEntity = await _aircraftRepository.GetByIdAsync(id);

            if (aircraftEntity == null)
            {
                return false;
            }

            await _aircraftRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<AircraftDTO>> GetAllAsync()
        {
            var aircraftEntities = await _aircraftRepository.GetAllAsync();

            return aircraftEntities.Select(aircraftEntities => new AircraftDTO
            {
                Id = aircraftEntities.Id,
                Type = aircraftEntities.Type,
                Model = aircraftEntities.Model
            });
        }


        public async Task<AircraftDTO?> GetByIdAsync(long id)
        {
            var aircraftEntity = await _aircraftRepository.GetByIdAsync(id);

            if (aircraftEntity == null)
            {
                return null;
            }

            return new AircraftDTO
            {
                Id = aircraftEntity.Id,
                Type = aircraftEntity.Type,
                Model = aircraftEntity.Model
            };
        }

        public async Task<bool> UpdateAsync(long id, AircraftDTO aircraft)
        {
            var existingAircraft = await _aircraftRepository.GetByIdAsync(id);

            if (existingAircraft == null)
            {
                return false;
            }

            existingAircraft.Type = aircraft.Type;
            existingAircraft.Model = aircraft.Model;

            await _aircraftRepository.UpdateAsync(existingAircraft);

            return true;
        }
    }
}
