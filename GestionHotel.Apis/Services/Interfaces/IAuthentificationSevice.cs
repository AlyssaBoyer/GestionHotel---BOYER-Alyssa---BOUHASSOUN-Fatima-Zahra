using System;

namespace GestionHotel.Apis.Services
{
    public interface IAuthentificationService
    {
        bool AuthentifierClient(string nom, string motDePasse);
        bool AuthentifierReceptionniste(string nom, string motDePasse);
        bool AuthentifierPersonnelMenage(string nom, string motDePasse);
    }
}