using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public class PersonnelMénageRepository : IPersonnelMénageRepository
    {
        // Simulons une liste de chambres pour l'exemple
        private List<Chambre> _chambres = new List<Chambre>
        {
            new Chambre { Id = 1, EstNettoyee = false, EstOccupee = true },
            new Chambre { Id = 2, EstNettoyee = false, EstOccupee = false },
            new Chambre { Id = 3, EstNettoyee = true, EstOccupee = false }
            // Ajoutez d'autres chambres au besoin
        };

        public List<Chambre> GetChambresANettoyer()
        {
            List<Chambre> chambresANettoyer = new List<Chambre>();
            foreach (var chambre in _chambres)
            {
                if (!chambre.EstOccupee && !chambre.EstNettoyee)
                {
                    chambresANettoyer.Add(chambre);
                }
            }
            return chambresANettoyer;
        }

        public void MarquerChambreCommeNettoyee(int chambreId)
        {
            var chambre = _chambres.Find(c => c.Id == chambreId);
            if (chambre != null)
            {
                chambre.EstNettoyee = true;
            }
        }
    }
}
