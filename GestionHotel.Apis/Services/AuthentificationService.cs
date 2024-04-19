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
            // Initialisation des utilisateurs (pour l'exemple)
            clients = new Dictionary<string, string>
            {
                {"client1", "password1"},
                {"client2", "password2"},
                // Ajouter d'autres clients au besoin
            };

            // Initialisation des réceptionnistes (pour l'exemple)
            receptionnistes = new Dictionary<string, string>
            {
                {"receptionniste1", "password1"},
                {"receptionniste2", "password2"},
            };

            personnesmenage = new Dictionary<string, string>
            {
                {"personnesmenage1", "password1"},
                {"personnesmenage2", "password2"},
                
            };
        }

        public bool AuthentifierClient(Client client)
        {
            if (clients.ContainsKey(client.Nom) && clients[client.Nom] == client.MotPasse)
            {
                Console.WriteLine($"Le client {client.Nom} est authentifié avec succès.");
                return true;
            }
            else
            {
                Console.WriteLine($"L'authentification du client {client.Nom} a échoué.");
                return false;
            }
        }

        public bool AuthentifierReceptionniste(Receptionniste receptionniste)
        {
            // Vérifie si le réceptionniste existe dans le dictionnaire et si le mot de passe correspond
            if (receptionnistes.ContainsKey(receptionniste.Nom) && receptionnistes[receptionniste.Nom] == receptionniste.MotPasse)
            {
                Console.WriteLine($"Le réceptionniste {receptionniste.Nom} est authentifié avec succès.");
                return true;
            }
            else
            {
                Console.WriteLine($"L'authentification du réceptionniste {receptionniste.Nom} a échoué.");
                return false;
            }
        }

        public bool AuthentifierPersonneMenage(PersonnelMenage personnelMenage)
        {
            // Vérifie si le réceptionniste existe dans le dictionnaire et si le mot de passe correspond
            if (personnesmenage.ContainsKey(personnelMenage.Nom) && personnesmenage[personnelMenage.Nom] == personnelMenage.MotPasse)
            {
                Console.WriteLine($"Le personnel ménage {personnelMenage.Nom} est authentifié avec succès.");
                return true;
            }
            else
            {
                Console.WriteLine($"L'authentification du personnel ménage {personnelMenage.Nom} a échoué.");
                return false;
            }
        }

        public string[] ObtenirRoles(string username)
        {
            if (utilisateurs.ContainsKey(username))
            {
                if (utilisateurs[username] is Client)
                {
                    return new string[] { "Client" };
                }
                else if (utilisateurs[username] is Receptionniste)
                {
                    return new string[] { "Receptionniste" };
                }else if (utilisateurs[username] is PersonnelMenage)
                {
                    return new string[] { "PersonnelMenage" };
                }
            }
            return new string[0];
        }

    }
}
