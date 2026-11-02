# Catalog

A small ASP.NET Core Web API for managing merchants, their catalogs and catalog items, built with onion architecture on .NET 10 and EF Core (SQL Server).

## Architecture

```
Source/Catalog
├── Domain           Entities (Merchant, Catalog, CatalogItem) and their rules; no dependencies
├── Application      Services, DTOs, repository/service interfaces → Domain
├── Infrastructure   EF Core DbContext, repositories, migrations, seed data → Application
└── Web              Controllers, composition root → Infrastructure
```

Dependencies point inward: Web → Infrastructure → Application → Domain.

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB, Express or full)
- EF Core CLI: `dotnet tool install --global dotnet-ef`

### Configure the database

The API reads the connection string named `Catalog`. Set it in `Source/Catalog/Web/appsettings.Development.json`, or keep credentials out of source control with user secrets:

```bash
cd Source/Catalog/Web
dotnet user-secrets set "ConnectionStrings:Catalog" "<your connection string>"
```

### Create the database

```bash
cd Source/Catalog
dotnet ef database update --project Infrastructure --startup-project Web
```

This applies all migrations and seeds two merchants (Zalando, Boozt) with catalogs and items.

### Run

```bash
cd Source/Catalog
dotnet run --project Web
```

The API listens on `http://localhost:5029` (and `https://localhost:7050` with the `https` profile). In Development the OpenAPI document is served at `/openapi/v1.json`.

`Source/Catalog/Web/Web.http` contains ready-to-run requests for every endpoint.

## API

| Method | Route | Description |
|---|---|---|
| GET | `/merchants` | List merchants |
| GET | `/merchants/{id}` | Get a merchant |
| POST | `/merchants` | Create a merchant |
| PUT | `/merchants/{id}` | Update a merchant |
| POST | `/merchants/{id}/activate` | Activate a merchant |
| POST | `/merchants/{id}/deactivate` | Deactivate a merchant and all its catalogs and items |
| GET | `/merchants/{merchantId}/catalogs` | List a merchant's catalogs |
| GET | `/merchants/{merchantId}/catalogs/{id}` | Get a catalog |
| POST | `/merchants/{merchantId}/catalogs` | Create a catalog |
| PUT | `/merchants/{merchantId}/catalogs/{id}` | Update a catalog |
| POST | `/merchants/{merchantId}/catalogs/{id}/activate` | Activate a catalog |
| POST | `/merchants/{merchantId}/catalogs/{id}/deactivate` | Deactivate a catalog and all its items |
| GET | `/catalogs/{catalogId}/items` | List a catalog's items |
| GET | `/catalogs/{catalogId}/items/{id}` | Get an item |
| POST | `/catalogs/{catalogId}/items` | Create an item |
| PUT | `/catalogs/{catalogId}/items/{id}` | Update an item |
| POST | `/catalogs/{catalogId}/items/{id}/activate` | Activate an item |
| POST | `/catalogs/{catalogId}/items/{id}/deactivate` | Deactivate an item |

Deactivation cascades down; activation does not, so children must be re-activated individually.

## Adding a migration

```bash
cd Source/Catalog
dotnet ef migrations add <Name> --project Infrastructure --startup-project Web
```
