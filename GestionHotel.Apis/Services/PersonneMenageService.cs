using System.Collections.Generic;
using GestionHotel.Apis.Models;
using GestionHotel.Infrastructure.Repository;

namespace GestionHotel.Apis.Services
{
    public class PersonnelMenageService
    {
        private readonly IPersonnelMenageRepository _personnelMenageRepository;

        public PersonnelMenageService(IPersonnelMenageRepository personnelMenageRepository)
        {
            _personnelMenageRepository = personnelMenageRepository;
        }

        public List<Chambre> GetChambresANettoyer()
        {
            return _personnelMenageRepository.GetChambresANettoyer();
        }

        public void MarquerChambreCommeNettoyee(int chambreId)
        {
            _personnelMenageRepository.MarquerChambreCommeNettoyee(chambreId);
        }
    }
}