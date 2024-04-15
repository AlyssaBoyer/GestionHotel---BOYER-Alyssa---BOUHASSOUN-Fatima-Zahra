using GestionHotel.Apis.Models;
using System.Collections.Generic;

namespace GestionHotel.Apis.Services
{
    public interface IReservationRepository
    {
        Reservation GetReservationById(int id);
        void AddReservation(Reservation reservation);
        void RemoveReservation(Reservation reservation);
        IEnumerable<Reservation> GetReservationsByDateRange(DateTime debut, DateTime fin);

    }
}
