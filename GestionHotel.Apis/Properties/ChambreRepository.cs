using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public interface IChambreRepository
    {
        Chambre GetChambreById(int id);
        // Autres méthodes de manipulation des données des chambres
    }

    public class ChambreRepository : IChambreRepository
    {
        private readonly ApplicationDbContext _context; // Supposons que ApplicationDbContext est votre contexte de base de données

        public ChambreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Chambre GetChambreById(int id)
        {
            return _context.Chambres.Find(id);
        }
    }
}