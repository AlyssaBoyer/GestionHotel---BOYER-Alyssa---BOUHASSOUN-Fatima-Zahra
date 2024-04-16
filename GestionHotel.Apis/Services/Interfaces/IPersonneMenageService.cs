using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public interface IPersonnelMenageService
    {
        List<Chambre> GetChambresANettoyer();
        void MarquerChambreCommeNettoyee(int chambreId);
    }
}