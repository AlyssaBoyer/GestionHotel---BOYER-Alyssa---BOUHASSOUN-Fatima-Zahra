using System.Collections.Generic;
using GestionHotel.Apis.Models;
using GestionHotel.Infrastructure.Repository;

namespace GestionHotel.Apis.Services
{
    public class PersonnelMénageService
    {
        private readonly IPersonnelMénageRepository _personnelMénageRepository;

        public PersonnelMénageService(IPersonnelMénageRepository personnelMénageRepository)
        {
            _personnelMénageRepository = personnelMénageRepository;
        }

        public List<Chambre> GetChambresANettoyer()
        {
            return _personnelMénageRepository.GetChambresANettoyer();
        }

        public void MarquerChambreCommeNettoyee(int chambreId)
        {
            _personnelMénageRepository.MarquerChambreCommeNettoyee(chambreId);
        }
    }
}