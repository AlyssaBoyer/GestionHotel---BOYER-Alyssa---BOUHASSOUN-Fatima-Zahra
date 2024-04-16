using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public interface IPersonnelMénageRepository
    {
        List<Chambre> GetChambresANettoyer();
        void MarquerChambreCommeNettoyee(int chambreId);
    }
}