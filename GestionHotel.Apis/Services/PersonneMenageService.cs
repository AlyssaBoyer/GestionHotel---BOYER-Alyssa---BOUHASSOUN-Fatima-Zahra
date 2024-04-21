using System.Collections.Generic;
using GestionHotel.Apis.Infrastructure.Repository;
using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Services.Interfaces;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public class PersonnelMenageService : IPersonnelMenageService
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
        
        public void MarquerChambrePourNettoyage(int chambreId)
        {
            _personnelMenageRepository.MarquerChambrePourNettoyage(chambreId);
        }
    }
}