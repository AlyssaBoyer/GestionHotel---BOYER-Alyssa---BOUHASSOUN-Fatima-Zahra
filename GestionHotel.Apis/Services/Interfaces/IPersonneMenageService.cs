using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services.Interfaces
{
    public interface IPersonnelMenageService
    {
        List<Chambre> GetChambresANettoyer();
        void MarquerChambreCommeNettoyee(int chambreId);
        void MarquerChambrePourNettoyage(int chambreId);
    }
}