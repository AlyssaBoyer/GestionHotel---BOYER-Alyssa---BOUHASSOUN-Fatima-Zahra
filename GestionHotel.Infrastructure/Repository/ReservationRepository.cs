using System;
using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
        Reservation GetReservationById(int id);
        IEnumerable<Reservation> GetReservationsByDateRange(DateTime debut, DateTime fin);
        void RemoveReservation(Reservation reservation);
    }
}
