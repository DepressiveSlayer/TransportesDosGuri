using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationDTO> CreateAsync(ReservationDTO reservation)
        {
            var reservationEntity = new Reservation
            {
                ApplicationUserId = reservation.ApplicationUserId,
                FlightSeatId = reservation.FlightSeatId,
                PurchaseId = reservation.PurchaseId,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status,
                Price = reservation.Price
            };

            await _reservationRepository.AddAsync(reservationEntity);

            reservation.Id = reservationEntity.Id;

            return reservation;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var reservationEntity = await _reservationRepository.GetByIdAsync(id);

            if (reservationEntity == null)
            {
                return false;
            }

            await _reservationRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllAsync()
        {
            var reservationEntities = await _reservationRepository.GetAllAsync();

            return reservationEntities.Select(reservationEntities => new ReservationDTO
            {
                Id = reservationEntities.Id,
                ApplicationUserId = reservationEntities.ApplicationUserId,
                FlightSeatId = reservationEntities.FlightSeatId,
                PurchaseId = reservationEntities.PurchaseId,
                ReservationDate = reservationEntities.ReservationDate,
                Status = reservationEntities.Status,
                Price = reservationEntities.Price
            });
        }

        public async Task<ReservationDTO?> GetByIdAsync(long id)
        {
            var reservationEntity = await _reservationRepository.GetByIdAsync(id);

            if (reservationEntity == null)
            {
                return null;
            }

            return new ReservationDTO
            {
                Id = reservationEntity.Id,
                ApplicationUserId = reservationEntity.ApplicationUserId,
                FlightSeatId = reservationEntity.FlightSeatId,
                PurchaseId = reservationEntity.PurchaseId,
                ReservationDate = reservationEntity.ReservationDate,
                Status = reservationEntity.Status,
                Price = reservationEntity.Price
            };
        }

        public async Task<bool> UpdateAsync(long id, ReservationDTO reservation)
        {
            var existingReservation = await _reservationRepository.GetByIdAsync(id);

            if (existingReservation == null)
            {
                return false;
            }

            existingReservation.ApplicationUserId = reservation.ApplicationUserId;
            existingReservation.FlightSeatId = reservation.FlightSeatId;
            existingReservation.PurchaseId = reservation.PurchaseId;
            existingReservation.ReservationDate = reservation.ReservationDate;
            existingReservation.ReservationDate = reservation.ReservationDate;
            existingReservation.Status = reservation.Status;
            existingReservation.Price = reservation.Price;

            await _reservationRepository.UpdateAsync(existingReservation);

            return true;
        }
    }
}
