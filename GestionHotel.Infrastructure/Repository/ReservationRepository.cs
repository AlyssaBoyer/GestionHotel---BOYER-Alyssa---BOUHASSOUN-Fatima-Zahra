using GestionHotel.Apis.Models;
using System;
using System.Collections.Generic;

namespace GestionHotel.Apis.Services
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public void AddReservation(Reservation reservation)
        {
             _reservationRepository.Add(reservation);
        }

        public Reservation GetReservationById(int id)
        {
           return _reservationRepository.GetById(id);
        }

        public IEnumerable<Reservation> GetReservationsByDateRange(DateTime debut, DateTime fin)
        {
            return _reservationRepository.GetByDateRange(debut, fin);
        }

        public void RemoveReservation(Reservation reservation)
        {
            _reservationRepository.Remove(reservation);
        }
    }
}