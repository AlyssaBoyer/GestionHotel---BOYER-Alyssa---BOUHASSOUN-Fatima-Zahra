using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public interface IReservationRepository
    {
        Reservation GetReservationById(int id);
        // Autres méthodes de manipulation des données des réservations
    }

    public class ReservationRepository : IReservationRepository
    {
        // Implémentation de l'accès aux données des réservations
    }
}