using System;
using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly Dictionary<string, string> clients; // Dictionnaire des clients (Nom, Mot de passe)
        private readonly Dictionary<string, string> receptionnistes; // Dictionnaire des réceptionnistes (Nom, Mot de passe)

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
                // Ajouter d'autres réceptionnistes au besoin
            };
        }

        public bool AuthentifierClient(Client client)
        {
            // Vérifie si le client existe dans le dictionnaire et si le mot de passe correspond
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
        public string[] ObtenirRoles(string username)
        {
            // Logique pour obtenir les rôles de l'utilisateur
            // Par exemple, vous pouvez accéder à une base de données ou à un autre système pour obtenir les rôles de l'utilisateur
            // Pour cet exemple, nous allons retourner des rôles factices
            if (utilisateurs.ContainsKey(username))
            {
                // Vérifie le type d'utilisateur
                if (utilisateurs[username] is Client)
                {
                    return new string[] { "Client" };
                }
                else if (utilisateurs[username] is Receptionniste)
                {
                    return new string[] { "Receptionniste" };
                }
            }

            // Si l'utilisateur n'est pas trouvé ou si son type n'est pas géré, retourne un tableau vide
            return new string[0];
        }

    }
}
