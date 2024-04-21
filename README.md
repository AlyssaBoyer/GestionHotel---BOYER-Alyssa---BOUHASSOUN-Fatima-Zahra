# Système de Gestion d'Hôtel - API

Ce projet est une application API web conçue pour la gestion d'un hôtel. Il couvre des fonctionnalités telles que la réservation de chambres, la gestion des clients et du personnel, et les services de l'hôtel.

## Prérequis

Avant de commencer, assurez-vous d'avoir les outils suivants installés :
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Git](https://git-scm.com/downloads) pour cloner le projet
- [Visual Studio](https://visualstudio.microsoft.com/fr/) ou [JetBrains Rider](https://www.jetbrains.com/rider/) (ou un autre IDE compatible avec .NET)

## Installation

1. Clonez le dépôt Git :
    ```sh
    git clone https://github.com/AlyssaBoyer/GestionHotel---BOYER-Alyssa---BOUHASSOUN-Fatima-Zahra.git
    ```
2. Accédez au répertoire du projet cloné.

3. Restaurez les packages NuGet :
    ```sh
    dotnet restore
    ```

4. Lancez le projet via l'IDE qui configurera et utilisera IIS Express par défaut, ou via la commande suivante pour un serveur Kestrel :
    ```sh
    dotnet run
    ```

5. Si vous utilisez Visual Studio ou Rider, assurez-vous que IIS Express est sélectionné comme profil de lancement. Accédez ensuite à `https://localhost:44376/swagger` pour voir l'interface Swagger et tester les endpoints API.

## Configuration de la Base de Données

Le projet est configuré pour utiliser une base de données SQLite. Vous devez créer des enregistrements initiaux pour les chambres et les utilisateurs :

1. Ouvrez la console de gestion de package ou un terminal et exécutez les migrations :
    ```sh
    dotnet ef database update
    ```

2. Utilisez les scripts SQL fournis ou un outil tel que [DB Browser for SQLite](https://sqlitebrowser.org/) pour peupler la base de données avec des données initiales.

## Utilisation

L'API est maintenant accessible via l'adresse `https://localhost:44376/api/`. Utilisez Swagger UI pour explorer les différents endpoints et leurs fonctionnalités.




**Auteurs**
Ce projet a été développé par Fatima-Zahra, Alyssa et Marion