# FE_React_CompanyTest (Next.js)

Frontend Next.js (React) per il backend `API_CompanyTest`.

## Architettura

- `src/dto/`: DTO TypeScript usati per parlare con le API del backend
- `src/api/`: client API verso il back (fetch wrapper + moduli per auth/prodotti/ordini/reclami)
- `src/components/`: componenti riutilizzabili (layout, UI, auth)
- `src/pagine/`: pagine “logiche” (la route Next in `src/pages/` importa da qui)

## Backend: rotte usate

- Auth:
  - `POST /v1/Auth/register`
  - `POST /v1/Auth/login`
- Products (richiede JWT + AdminLevel >= 1):
  - `GET /v1/Products/get-all`
  - `POST /v1/Products/create`
  - `PATCH /v1/Products/update`
  - `DELETE /v1/Products/delete/{id}`
- Orders (DTO tabellare join/SP):
  - `GET /v1/Orders/ordersTable/{from}/{amount}`
- Claims (DTO tabellare join/SP):
  - `POST /v1/Claims/claims-table`

## Config

Crea un `.env.local` partendo da `.env.local.example`:

```bash
copy .env.local.example .env.local
```

Poi avvia:

```bash
npm install
npm run dev
```

## Nota importante (baseUrl e CORS)

Se ti dà errore login ma il backend “va”, di solito sono 2 cose:

- baseUrl sbagliato: il backend da `launchSettings.json` gira tipicamente su `https://localhost:7110` o `http://localhost:5092`.
- CORS: nel `Program.cs` del backend non vedo configurazione CORS. Dal browser, chiamare il backend da `http://localhost:3000` può essere bloccato.

