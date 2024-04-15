using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
        void RemoveReservation(Reservation reservation);
        Reservation GetReservationById(int id);
        IEnumerable<Chambre> GetChambresReserveesEntreDates(DateTime debut, DateTime fin);
        // Autres méthodes de manipulation des données des réservations
    }

    public class ReservationRepository : IReservationRepository
    {
        // Supposons que vous avez une liste de réservations dans votre système
        private readonly List<Reservation> _reservations;
        public ReservationRepository()
        {
            _reservations = new List<Reservation>();
            // Initialiser la liste des réservations avec des données fictives ou récupérées de la base de données
        }
        public void AddReservation(Reservation reservation)
        {
            // Ajouter la nouvelle réservation à la liste des réservations
            _reservations.Add(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {
            // Supprimer la réservation de la liste des réservations
            _reservations.Remove(reservation);
        }
        public IEnumerable<Chambre> GetChambresReserveesEntreDates(DateTime debut, DateTime fin)
        {
            var chambresReservees = new List<Chambre>();

            foreach (var reservation in _reservations)
            {
                // Vérifier si la réservation intersecte les dates données
                if (reservation.DateDebut <= fin && reservation.DateFin >= debut)
                {
                    // Si oui, ajouter la chambre associée à la réservation à la liste des chambres réservées
                    chambresReservees.Add(reservation.Chambre);
                }
            }

            return chambresReservees;
        }
        // Implémentez ici d'autres méthodes pour ajouter, supprimer ou mettre à jour les réservations
    }
}