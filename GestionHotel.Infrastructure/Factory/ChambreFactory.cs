using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Factory.Interface
{
    public class ReservationFactory : IReservationFactory
    {
        private readonly IChambreRepository _chambreRepository;
        private readonly IPaiementService _paiementService; // Supposons qu'il existe un service pour gérer les paiements

        public ReservationService(IChambreRepository chambreRepository, IPaiementService paiementService)
        {
            _chambreRepository = chambreRepository;
            _paiementService = paiementService;
        }

        public Reservation CreateReservation(Client client, Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit)
        {
            // Vérifier la disponibilité de la chambre pour les dates spécifiées
            bool chambreDisponible = CheckChambreDisponible(chambre, debut, fin);

            if (!chambreDisponible)
            {
                throw new Exception("La chambre sélectionnée n'est pas disponible pour les dates spécifiées.");
            }

            // Calculer le montant de la réservation
            decimal montantReservation = CalculerMontantReservation(chambre, debut, fin);

            // Effectuer le paiement
            bool paiementReussi = _paiementService.ProcessPayment(numeroCarteCredit, montantReservation);

            if (!paiementReussi)
            {
                throw new Exception("Le paiement a échoué. Impossible de créer la réservation.");
            }

            // Créer l'objet Reservation
            Reservation reservation = new Reservation
            {
                Client = client,
                Chambre = chambre,
                DateDebut = debut,
                DateFin = fin,
                StatutPaiement = true, // Supposons que le paiement a réussi
                // Autres propriétés de la réservation
            };

            // Enregistrer la réservation dans la base de données ou dans une liste en mémoire, selon votre architecture
            // Exemple avec l'utilisation du repository :
            //_reservationRepository.SaveReservation(reservation);

            return reservation;
        }

        // Méthodes auxiliaires pour vérifier la disponibilité de la chambre et calculer le montant de la réservation
        private bool CheckChambreDisponible(Chambre chambre, DateTime debut, DateTime fin)
        {
            // Récupérer les réservations existantes pour la chambre spécifiée
            List<Reservation> reservations = _chambreRepository.GetReservationsForChambre(chambre.Id);

            // Vérifier si une réservation existe pour les dates spécifiées
            bool isAvailable = !reservations.Any(r =>
                (debut >= r.DateDebut && debut < r.DateFin) || // Vérifie si le début de la nouvelle réservation est dans une réservation existante
                (fin > r.DateDebut && fin <= r.DateFin) ||   // Vérifie si la fin de la nouvelle réservation est dans une réservation existante
                (debut <= r.DateDebut && fin >= r.DateFin)   // Vérifie si la nouvelle réservation chevauche une réservation existante
            );

            return isAvailable;

        }

        private decimal CalculerMontantReservation(Chambre chambre, DateTime debut, DateTime fin)
        {

              // Calculer le nombre de jours de séjour
             int nombreJours = (int)(fin - debut).TotalDays;

             // Calculer le montant total en multipliant le tarif journalier de la chambre par le nombre de jours
             decimal montantTotal = chambre.Tarif * nombreJours;

             return montantTotal;
        }
    }
}
