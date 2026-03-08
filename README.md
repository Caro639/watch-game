# WatchGame

Application web ASP.NET Core MVC de gestion d'un catalogue de jeux vidéo. Elle permet de lister, rechercher, filtrer et administrer des jeux via une interface CRUD complète.

## Fonctionnalités

- **Liste des jeux** avec recherche par titre et filtre par genre
- **Fiche détaillée** d'un jeu
- **Création, modification et suppression** de jeux
- **Données initiales** chargées automatiquement au démarrage (seed)

## Stack technique

| Couche                 | Technologie                                          |
| ---------------------- | ---------------------------------------------------- |
| Framework              | ASP.NET Core MVC (.NET 10)                           |
| ORM                    | Entity Framework Core 10                             |
| Base de données (dev)  | SQLite                                               |
| Base de données (prod) | SQL Server                                           |
| Vue                    | Razor Views + Bootstrap                              |
| Validation             | Data Annotations + `Microsoft.Extensions.Validation` |

## Structure du projet

```
WatchGame/
├── Controllers/
│   ├── GamesController.cs       # CRUD complet + recherche/filtre
│   ├── HomeController.cs
│   └── HelloWorldController.cs
├── Models/
│   ├── Game.cs                  # Entité principale
│   ├── GameGenreViewModel.cs    # ViewModel liste + filtre
│   ├── SeedData.cs              # Données initiales
│   └── ErrorViewModel.cs
├── Data/
│   └── WatchGameContext.cs      # DbContext EF Core
├── Migrations/                  # Migrations EF Core
├── Views/
│   ├── Games/                   # Index, Details, Create, Edit, Delete
│   ├── Home/
│   ├── HelloWorld/
│   └── Shared/
├── Program.cs
└── appsettings.json
```

## Modèle `Game`

| Champ         | Type       | Contraintes                                           |
| ------------- | ---------- | ----------------------------------------------------- |
| `Id`          | `int`      | Clé primaire auto-générée                             |
| `Title`       | `string`   | Requis, 3 à 60 caractères                             |
| `ReleaseDate` | `DateTime` | Format date                                           |
| `Genre`       | `string`   | Requis, max 30 caractères, commence par une majuscule |
| `Price`       | `decimal`  | 1 à 100, `decimal(18,2)`                              |
| `Rating`      | `string`   | Requis, max 5 caractères (ex. `PG`, `R`)              |

## Prérequis

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- (Optionnel) SQL Server pour l'environnement de production

## Installation et lancement

```bash
# Cloner le dépôt
git clone https://github.com/Caro639/watch-game.git
cd watch-game

# Restaurer les dépendances
dotnet restore

# Appliquer les migrations et créer la base de données
dotnet ef database update

# Lancer l'application
dotnet run
```

L'application sera disponible sur `https://localhost:5001` (ou le port affiché dans la console).

## Configuration

La chaîne de connexion SQLite est définie dans `appsettings.Development.json` :

```json
{
  "ConnectionStrings": {
    "WatchGameContext": "Data Source=WatchGame.db"
  }
}
```

Pour la production, renseignez `ProductionWatchGameContext` dans `appsettings.json` avec une chaîne de connexion SQL Server.

## Migrations EF Core

```bash
# Ajouter une nouvelle migration
dotnet ef migrations add <NomDeLaMigration>

# Appliquer les migrations
dotnet ef database update
```

## Licence

Ce projet est à titre éducatif, basé sur le tutoriel officiel Microsoft ASP.NET Core MVC.
