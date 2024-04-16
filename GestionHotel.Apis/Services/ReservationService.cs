using GestionHotel.Apis.Models;
using GestionHotel.Apis.Services.Interfaces;
using GestionHotel.Infrastructure.Repository;
using GestionHotel.Models;

namespace GestionHotel.Apis.Services
{
    public class ReservationService 
    {
        private readonly ChambreRepository _chambreRepository;
        private readonly PaiementService _paiementService;
        private readonly ReservationRepository _reservationRepository;
        // Autres dépendances injectées

        public ReservationService(ChambreRepository chambreRepository, PaiementService paiementService, ReservationRepository reservationRepository)
        {
            _chambreRepository = chambreRepository;
            _paiementService = paiementService;
            _reservationRepository = reservationRepository;
            // Initialisation d'autres dépendances
        }
        
        public decimal CalculerMontantReservation(Chambre chambre, DateTime debut, DateTime fin)
        {
            // Calculer la durée du séjour en jours
            TimeSpan dureeSejour = fin - debut;
            int nombreJours = dureeSejour.Days;

            // Calculer le montant total en fonction du tarif journalier de la chambre
            decimal montantTotal = chambre.Tarif * nombreJours;

            return montantTotal;
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

         public void GererArrivee(Reservation reservation)
        {
            // Vérifier les autorisations du réceptionniste
            if (!_authService.IsReceptionniste())
            {
                throw new UnauthorizedAccessException("Seul le réceptionniste peut gérer l'arrivée.");
            }

            // Marquer la chambre comme occupée
            reservation.Chambre.Etat = "Occupée";

            // Gérer les paiements non effectués
            if (!reservation.PaiementEffectue)
            {
                // Si le paiement n'a pas été effectué, tentez à nouveau de traiter le paiement
                _paiementService.ProcessPayment(reservation.Client.NumeroCarteCredit, reservation.Montant);
                reservation.PaiementEffectue = true; // Marquer le paiement comme effectué
            }

            // Mettre à jour la réservation dans le repository
            _reservationRepository.UpdateReservation(reservation);
        }

        public void AnnulerReservation(Reservation reservation)
        {
            // Vérifier si la réservation est déjà annulée
            if (reservation == null || reservation.ChambreReservee.Etat == false)
            // Vérifier si la réservation existe et n'est pas déjà annulée
            if (reservation == null || !reservation.StatutPaiement)

            {
                throw new InvalidOperationException("La réservation est déjà annulée ou n'existe pas.");
            }
            // Marquer la réservation comme annulée
            reservation.ChambreReservee.Etat = false;

            // Vérifier les conditions de remboursement
            TimeSpan differenceJours = reservation.DateDebut - DateTime.Now;
            if (differenceJours.TotalDays > 7)
            {
                 Remboursement complet si l'annulation est faite plus de 7 jours avant
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
            reservation.EstAnnulee = true;
            // _reservationRepository.UpdateReservation(reservation);
        }
     }
}
