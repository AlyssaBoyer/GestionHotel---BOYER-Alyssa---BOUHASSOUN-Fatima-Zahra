using System;
using GestionHotel.Apis.Models;
using GestionHotel.Apis.Repositories;
using GestionHotel.Externals.PaiementGateways;

namespace GestionHotel.Apis.Services
{
    public interface IReservationService
    {
        Reservation ReserverChambre(Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit);
        void AnnulerReservation(Reservation reservation);
    }

    public class ReservationService : IReservationService
    {
        private readonly ReservationRepository _reservationRepository;
        private readonly IChambreRepository _chambreRepository;
        private readonly PaiementService _paiementService;

        public ReservationService(ReservationRepository reservationRepository,IChambreRepository chambreRepository, PaiementService paiementService)
        {
            _reservationRepository = reservationRepository;
            _chambreRepository = chambreRepository;
            _paiementService = paiementService;
        }

        public Reservation ReserverChambre(Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit)
        {
            // Créer une nouvelle réservation
            Reservation reservation = new Reservation
            {
                Chambre = chambre,
                DateDebut = debut,
                DateFin = fin
                // Ajouter d'autres propriétés de réservation au besoin
            };

            // Effectuer le paiement
            bool paiementEffectue = _paiementService.ProcessPayment(numeroCarteCredit, CalculerMontantReservation(chambre, debut, fin));

            // Si le paiement est réussi, enregistrer la réservation
            if (paiementEffectue)
            {
                _reservationRepository.AddReservation(reservation);
                return reservation;
            }
            else
            {
                // Gérer l'échec du paiement
                throw new Exception("Le paiement a échoué. La réservation n'a pas été effectuée.");
            }
        }

        public void AnnulerReservation(Reservation reservation)
        {
            // Annuler la réservation
            _reservationRepository.RemoveReservation(reservation);
            // Rembourser le client si nécessaire
            // Logique supplémentaire d'annulation de réservation
        }

        // Méthode utilitaire pour calculer le montant de la réservation
        private decimal CalculerMontantReservation(Chambre chambre, DateTime debut, DateTime fin)
        {
            // Implémenter la logique de calcul du montant en fonction des dates et des tarifs de la chambre
            // Cette logique peut être basée sur différents critères tels que la durée du séjour, le tarif de la chambre, etc.
            return 0; // Retourne un montant factice pour l'exemple
        }
        // Ajoutez une méthode pour récupérer les chambres réservées entre les dates données
        public IEnumerable<Chambre> GetChambresReservees(DateTime debut, DateTime fin)
        {
            return _reservationRepository.GetChambresReserveesEntreDates(debut, fin);
        }
    }
}