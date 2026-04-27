# CompanyManagement

Mini progetto “Company management” fatto per test/portfolio full-stack.
L’idea è semplice: **API in .NET 8 + DB SQL Server**, e due frontend:

- **WinForms** (desktop, dentro la solution)
- **React / Next.js** (web, in una cartella separata)

## Cosa c’è dentro (stack)

- **Backend**: ASP.NET Core Web API (.NET 8)
- **Auth**: JWT Bearer + Authorize sugli endpoint
- **DB**: Microsoft SQL Server (tipicamente SQL Express in locale)
- **Accesso dati**: EF Core (con DbContext scaffoldata) + in alcuni punti Dapper / Stored Procedure
- **Swagger**: abilitato in Development con panel per JWT
- **Frontend desktop**: WinForms (.NET 8 Windows)
- **Frontend web**: Next.js (React) con client HTTP leggero + token storage

## Struttura progetto (solution)

La solution è `CompanyTest/CompanyTest.sln` e contiene:

- `CompanyTest/API_CompanyTest`
  - Web API (Controllers, Services, Repositories, Middleware)
  - Config: `appsettings.json` (connection string + JWT)
- `CompanyTest/BE_CompanyTest`
  - Modelli + `DbContext` (scaffold da DB)
- `CompanyTest/DTO_CompanyTest`
  - DTO condivisi tra API e client (request/response)
- `CompanyTest/FE_CompanyTest`
  - WinForms UI + servizi che chiamano l’API

In più c’è una FE web separata:

- `CompanyTest/FE_React_CompanyTest`
  - Next.js con pagine + “api client” in `src/api/*`

## Architettura

Lato backend è una classica cosa a layer:

- **Controller** (HTTP)
  - Espongono le route tipo `v1/auth/*`, `v1/products/*`, ecc.
  - Validano “a grandi linee” e ritornano status code
- **Service** (business logic)
  - Qui sta la logica applicativa: controlli, orchestrazione, mapping, ecc.
- **Repository** (data access)
  - Incapsula chiamate a DB (EF / Dapper / SP)
- **DB**
  - SQL Server con tabelle tipo `Users`, `Products`, `Orders`, `Claims`, `Credentials`

In mezzo c’è anche un **middleware custom** (`MiddlewareLogger`) per loggare le richieste (giusto per avere un punto unico dove osservare roba che passa).

### Auth e permessi

- Gli endpoint “core” (es. Products/Orders/Claims) sono marcati con `[Authorize]`
- La FE salva il token e lo manda come header `Authorization: Bearer <token>`
- Alcuni endpoint fanno anche un controllo extra su una claim `AdminLevel` (se non hai il livello richiesto, ti blocca con 401/403)

## API 

Tutte le route stanno sotto `v1/`.

- **Auth**
  - `POST v1/auth/register`
  - `POST v1/auth/login`
- **Products** (protetto, richiede token)
  - `GET v1/products/get-all`
  - `GET v1/products/get-all-by-sp/{from}/{resultSize}`
  - `POST v1/products/create`
  - `POST v1/products/create-by-sp`
  - `PATCH v1/products/update`
  - `DELETE v1/products/delete/{id}`
- **Orders** (protetto)
  - `POST v1/orders/create`
  - `PATCH v1/orders/update/{id}`
  - `DELETE v1/orders/delete/{id}`
  - `GET v1/orders/ordersTable/{from}/{amount}`
- **Claims** (protetto)
  - `POST v1/claims/claims-table`

Tip: in dev puoi usare **Swagger** e incollare il JWT nella sezione “Authorize”.

## Configurazione

### Database (SQL Server)

La connection string sta in `CompanyTest/API_CompanyTest/appsettings.json`:

- `ConnectionStrings:DefaultConnection`


Nel progetto `BE_CompanyTest` c’è anche un `DbContext` con una connection string hardcoded (generata dallo scaffold): l’idea è che in un progetto “vero” questa cosa va tolta e si usa solo config/env, ma qui è rimasta perché è un test project.

### JWT

Sempre in `appsettings.json`:

- `Jwt:Key`
- `Jwt:Issuer`
- `Jwt:Audience`
- `Jwt:DurationInMinutes`


### CORS (Next.js)

L’API abilita una policy CORS “dev” per il frontend web su `http://localhost:3000` (e https).

### Next.js env

Il frontend web legge la base url API da:

- `NEXT_PUBLIC_API_BASE_URL`

Se non la setti, fa fallback su `https://localhost:7110`.

## Come si avvia

### Backend API (Swagger + HTTPS)

Da Visual Studio:

- imposta `API_CompanyTest` come startup project
- avvia in `Development`
- apri Swagger (di solito su una url tipo `https://localhost:7xxx/swagger`)

Da CLI (se preferisci):

```bash
cd "CompanyTest/API_CompanyTest"
dotnet restore
dotnet run
```

### Frontend WinForms

Da Visual Studio:

- startup project `FE_CompanyTest`
- run

La WinForms chiama l’API tramite i servizi (vedi `CompanyTest/FE_CompanyTest/Services/*`).

### Frontend Web (Next.js)

```bash
cd "CompanyTest/FE_React_CompanyTest"
npm install
npm run dev
```

Poi apri `http://localhost:3000`.

## Note “da progetto test”

- La parte DB è volutamente “pratica”: c’è un mix EF + Dapper/SP perché era un modo veloce per provare entrambe le strade.
- Il controllo permessi è basic (claim `AdminLevel`), non è una RBAC completa.
- Se qualcosa non torna, la prima cosa da controllare è: **porta API**, **certificato HTTPS**, e **connection string**.

## Credits

All rights to Mirko Mataluni.
