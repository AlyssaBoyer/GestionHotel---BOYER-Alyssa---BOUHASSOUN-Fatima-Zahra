using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository.Interfaces;

public interface IReservationRepository
{
    void AddReservation(Reservation reservation);
    void UpdateReservation(Reservation reservation);
}