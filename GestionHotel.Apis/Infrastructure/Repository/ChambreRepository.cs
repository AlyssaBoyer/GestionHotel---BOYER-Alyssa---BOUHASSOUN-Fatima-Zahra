using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository;

public class ChambreRepository : IChambreRepository
{
    private readonly HotelDbContext _context;

    public ChambreRepository(HotelDbContext context)
    {
        _context = context;
    }

    public Chambre GetChambreById(int id)
    {
        return _context.Chambres.FirstOrDefault(chambre => chambre.Id == id);
    }
  
    public bool IsChambreDisponible(int id, DateTime debut, DateTime fin)
    {
        return !_context.Reservations.Any(reservation => 
            reservation.ChambreReserveeId == id &&
            debut < reservation.DateFin && fin > reservation.DateDebut);
    }
    
    public IEnumerable<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
    {
        var chambresReservees = _context.Reservations
            .Where(reservation => debut < reservation.DateFin && fin > reservation.DateDebut)
            .Select(reservation => reservation.ChambreReserveeId)
            .Distinct();

        var chambresDisponibles = _context.Chambres
            .Where(chambre => !chambresReservees.Contains(chambre.Id));

        return chambresDisponibles.ToList();
    }
    
    public void UpdateChambre(Chambre chambre)
    {
        _context.Chambres.Update(chambre);
        _context.SaveChanges();
    }
}