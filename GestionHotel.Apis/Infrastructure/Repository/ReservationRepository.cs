using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository;

public class ReservationRepository : IReservationRepository
{
    private readonly HotelDbContext _context;

    public ReservationRepository(HotelDbContext context)
    {
        _context = context;
    }

    public void AddReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
    }

    public void UpdateReservation(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        _context.SaveChanges();
    }
    
    public Reservation GetReservationById(int id)
    {
        return _context.Reservations.FirstOrDefault(reservation => reservation.Id == id);
    }

}