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

        public void AnnulerReservation(Reservation reservation)
        {
            // Vérifier si la réservation est déjà annulée
            if (reservation == null || reservation.ChambreReservee.Etat == false)
            {
                // Si la réservation est déjà annulée, rien à faire
                return;
            }
            // Marquer la réservation comme annulée
            reservation.ChambreReservee.Etat = false;

            // Mettre à jour le statut de paiement à false
            reservation.StatutPaiement = false;
        }
    }
}
