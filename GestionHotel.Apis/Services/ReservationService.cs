using GestionHotel.Apis.Models
using GestionHotel.Infrastructure.Repository;

namespace GestionHotel.Apis.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IChambreRepository _chambreRepository;
        // Autres dépendances injectées

        public ReservationService(IChambreRepository chambreRepository)
        {
            _chambreRepository = chambreRepository;
            // Initialisation d'autres dépendances
        }

        public Reservation ReserverChambre(Client client, Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit)
        {
                      // Vérifier si la chambre est disponible pour la plage de dates donnée
            var chambresDisponibles = _chambreRepository.GetChambresDisponibles(debut, fin);
            bool chambreDisponible = false;
            foreach (var chambreDispo in chambresDisponibles)
            {
                if (chambreDispo.Id == chambre.Id)
                {
                    chambreDisponible = true;
                    break;
                }
            }

            if (!chambreDisponible)
            {
                throw new Exception("La chambre n'est pas disponible pour les dates sélectionnées.");
            }

            // Effectuer le paiement
            bool paiementEffectue = _paiementService.ProcessPayment(numeroCarteCredit, CalculerMontantReservation(chambre, debut, fin));

            if (!paiementEffectue)
            {
                throw new Exception("Le paiement a échoué. La réservation n'a pas été effectuée.");
            }

            // Créer la réservation
            var reservation = new Reservation
            {
                Client = client,
                ChambreReservee = chambre,
                DateDebut = debut,
                DateFin = fin,
                StatutPaiement = true
            };

            // Enregistrer la réservation
            _reservationRepository.AddReservation(reservation);

            return reservation;
        }

        public void AnnulerReservation(Reservation reservation)
        {
            // Implémentation de l'annulation de réservation
        }

        private decimal CalculerMontantReservation(Chambre chambre, DateTime debut, DateTime fin)
        {
            // Calculer la durée du séjour en jours
            int dureeSejour = (int)(fin - debut).TotalDays;

            // Calculer le montant total en multipliant la durée du séjour par le tarif de la chambre
            decimal montantTotal = dureeSejour * chambre.Tarif;

            return montantTotal;
        }
     }
}
