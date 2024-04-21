using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository.Interfaces;

public interface IPersonnelMenageRepository
{
    List<Chambre> GetChambresANettoyer();
    void MarquerChambreCommeNettoyee(int chambreId);
    void MarquerChambrePourNettoyage(int chambreId);

}