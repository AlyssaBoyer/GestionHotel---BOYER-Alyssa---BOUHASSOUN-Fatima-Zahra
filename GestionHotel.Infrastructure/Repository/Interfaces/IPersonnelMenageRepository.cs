using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public interface IPersonnelMenageRepository
    {
        List<Chambre> GetChambresANettoyer();
        void MarquerChambreCommeNettoyee(int chambreId);
    }
}