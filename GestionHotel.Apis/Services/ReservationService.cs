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
 // Vérifier si la réservation existe et n'est pas déjà annulée
            if (reservation == null || !reservation.StatutPaiement)
            {
                throw new InvalidOperationException("La réservation est déjà annulée ou n'existe pas.");
            }

            // Vérifier les conditions de remboursement
            TimeSpan differenceJours = reservation.DateDebut - DateTime.Now;
            if (differenceJours.TotalDays > 7)
            {
                // Remboursement complet si l'annulation est faite plus de 7 jours avant
                _paiementService.ProcessRefund(reservation.Client, reservation.Montant);
            }
            else if (differenceJours.TotalDays > 1)
            {
                // Remboursement à 50% si l'annulation est faite entre 1 et 7 jours avant
                _paiementService.ProcessRefund(reservation.Client, reservation.Montant * 0.5);
            }
            else
            {
                // Pas de remboursement si l'annulation est faite moins de 24 heures avant
                // Vous pouvez enregistrer cette information ou notifier le client
            }

            // Mettre à jour le statut de la réservation
            reservation.StatutPaiement = false;
            reservation.EstAnnulee = true; // Assurez-vous que le modèle de réservation a un champ pour marquer comme annulée
            _reservationRepository.UpdateReservation(reservation);
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
