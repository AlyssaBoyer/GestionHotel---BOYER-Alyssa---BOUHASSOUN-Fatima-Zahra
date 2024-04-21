using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository;

public class PersonnelMenageRepository : IPersonnelMenageRepository
{
    private readonly HotelDbContext _context;

    public PersonnelMenageRepository(HotelDbContext context)
    {
        _context = context;
    }

    public List<Chambre> GetChambresANettoyer()
    {
        return _context.Chambres.Where(c => c.EstANettoyer && !c.EstNettoyee).ToList();
    }

    public void MarquerChambreCommeNettoyee(int chambreId)
    {
        var chambre = _context.Chambres.Find(chambreId);
        if (chambre != null)
        {
            chambre.EstNettoyee = true;
            chambre.EstANettoyer = false;
            _context.SaveChanges();
        }
    }

    public void MarquerChambrePourNettoyage(int chambreId)
    {
        var chambre = _context.Chambres.Find(chambreId);
        if (chambre != null)
        {
            chambre.EstANettoyer = true;
            _context.SaveChanges();
        }
    }
}
