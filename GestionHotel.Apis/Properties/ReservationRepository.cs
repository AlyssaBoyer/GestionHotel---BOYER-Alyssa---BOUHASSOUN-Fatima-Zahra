using GestionHotel.Apis.Models;
using GestionHotel.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public class ReservationRepository
    {
        private readonly List<Reservation> _reservations; // Supposons que _reservations est votre source de données

        public ReservationRepository()
        {
            // Initialisation de la liste des réservations (c'est un exemple, vous devez charger les données depuis votre source de données)
            _reservations = new List<Reservation>();
        }

        public void AddReservation(Reservation reservation)
        {
            // Ajouter la nouvelle réservation à la liste des réservations
            _reservations.Add(reservation);
        }
        
        
    
    }
}