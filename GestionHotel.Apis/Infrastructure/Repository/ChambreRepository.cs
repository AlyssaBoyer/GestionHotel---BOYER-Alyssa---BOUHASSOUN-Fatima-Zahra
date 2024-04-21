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
        return _context.Chambre.FirstOrDefault(chambre => chambre.Id == id);
    }
  
    public bool IsChambreDisponible(int id, DateTime debut, DateTime fin)
    {
        // Vérifier si une chambre spécifique est disponible pendant une période donnée
        return !_context.Reservations.Any(reservation => 
            reservation.ChambreReserveeId == id &&
            debut < reservation.DateFin && fin > reservation.DateDebut);
    }
}