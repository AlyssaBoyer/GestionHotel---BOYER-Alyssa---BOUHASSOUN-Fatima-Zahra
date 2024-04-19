using System;
using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly Dictionary<string, string> clients; // Dictionnaire des clients (Nom, Mot de passe)
        private readonly Dictionary<string, string> receptionnistes; // Dictionnaire des réceptionnistes (Nom, Mot de passe)
        private readonly Dictionary<string, string> personnesmenage;
        public AuthentificationService()
        {
            annuaireClients = new Dictionary<string, string>
            {
                {"client1", "password1"},
                {"client2", "password2"},
            };
            annuaireReceptionnistes = new Dictionary<string, string>
            {
                {"receptionniste1", "password1"},
                {"receptionniste2", "password2"},
            };

            annuairePersonnelMenage = new Dictionary<string, string>
            {
                {"personnesmenage1", "password1"},
                {"personnesmenage2", "password2"},
                
            };
        }
public bool AuthentifierClient(string nom, string motDePasse)
    {
        return Authentifier(nom, motDePasse, annuaireClients);
    }

    public bool AuthentifierReceptionniste(string nom, string motDePasse)
    {
        return Authentifier(nom, motDePasse, annuaireReceptionnistes);
    }

    public bool AuthentifierPersonnelMenage(string nom, string motDePasse)
    {
        return Authentifier(nom, motDePasse, annuairePersonnelMenage);
    }

    private bool Authentifier(string nom, string motDePasse, Dictionary<string, string> annuaire)
    {
        if (annuaire.ContainsKey(nom) && annuaire[nom] == motDePasse)
        {
            Console.WriteLine($"La personne {nom} est authentifiée avec succès.");
            return true;
        }
        else
        {
            Console.WriteLine($"L'authentification de {nom} a échoué.");
            return false;
        }
    }
    }
}
