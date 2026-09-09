using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<ScheduleDTO> CreateAsync(ScheduleDTO schedule)
        {
            var scheduleEntity = new Schedule
            {
                FlightId = schedule.FlightId,
                AirportId = schedule.AirportId,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime
            };

            await _scheduleRepository.AddAsync(scheduleEntity);

            schedule.Id = scheduleEntity.Id;

            return schedule;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var scheduleEntity = await _scheduleRepository.GetByIdAsync(id);

            if (scheduleEntity == null)
            {
                return false;
            }

            await _scheduleRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllAsync()
        {
            var scheduleEntities = await _scheduleRepository.GetAllAsync();

            return scheduleEntities.Select(scheduleEntities => new ScheduleDTO
            {
                Id = scheduleEntities.Id,
                FlightId = scheduleEntities.FlightId,
                AirportId = scheduleEntities.AirportId,
                DepartureTime = scheduleEntities.DepartureTime,
                ArrivalTime = scheduleEntities.ArrivalTime
            });

        }

        public async Task<ScheduleDTO?> GetByIdAsync(long id)
        {
            var scheduleEntity = await _scheduleRepository.GetByIdAsync(id);

            if (scheduleEntity == null)
            {
                return null;
            }

            return new ScheduleDTO
            {
                Id = scheduleEntity.Id,
                FlightId = scheduleEntity.FlightId,
                AirportId = scheduleEntity.AirportId,
                DepartureTime = scheduleEntity.DepartureTime,
                ArrivalTime = scheduleEntity.ArrivalTime
            };
        }

        public async Task<bool> UpdateAsync(long id, ScheduleDTO schedule)
        {
            var existingSchedule = await _scheduleRepository.GetByIdAsync(id);

            if (existingSchedule == null)
            {
                return false;
            }

            existingSchedule.FlightId = schedule.FlightId;
            existingSchedule.AirportId = schedule.AirportId;
            existingSchedule.DepartureTime = schedule.DepartureTime;
            existingSchedule.ArrivalTime = schedule.ArrivalTime;

            await _scheduleRepository.UpdateAsync(existingSchedule);

            return true;
        }
    }
}
