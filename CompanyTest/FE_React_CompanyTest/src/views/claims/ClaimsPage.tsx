import Head from "next/head";
import { useEffect, useState } from "react";
import { claimsApi } from "@/api/claimsApi";
import { ApiError } from "@/api/httpClient";
import type { ClaimsTableDto } from "@/dto/claimsDto";
import { AppShell } from "@/components/layout/AppShell";
import { useRequireAuth } from "@/components/auth/useRequireAuth";
import { Button } from "@/components/ui/Button";

export function ClaimsPage() {
  const { isReady, token } = useRequireAuth();

  const [items, setItems] = useState<ClaimsTableDto[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [errorText, setErrorText] = useState<string | null>(null);

  const load = async () => {
    setErrorText(null);
    setIsLoading(true);
    try {
      const result = await claimsApi.getClaimsTable();
      setItems(result ?? []);
    } catch (error) {
      if (error instanceof ApiError) {
        setErrorText(
          error.bodyText ??
            "Errore nel caricamento reclami. (Possibile: token non valido o CORS)."
        );
      } else {
        setErrorText("Errore nel caricamento reclami.");
      }
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    if (!isReady || !token) return;
    void load();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isReady, token]);

  if (!isReady || !token) return null;

  return (
    <>
      <Head>
        <title>Reclami - CompanyTest</title>
      </Head>

      <AppShell title="Reclami">
        <div
          style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            gap: 12,
          }}
        >
          <div>
            <h1 style={{ marginTop: 0, marginBottom: 6 }}>Lista reclami</h1>
            <div style={{ opacity: 0.85, fontSize: 13 }}>
              Endpoint tabellare (DTO join / stored procedure):{" "}
              <code>POST v1/Claims/claims-table</code>
            </div>
          </div>
          <Button variant="secondary" onClick={load} disabled={isLoading}>
            {isLoading ? "Carico..." : "Aggiorna"}
          </Button>
        </div>

        {errorText ? (
          <div style={{ color: "#ffb4b4", marginTop: 12 }}>{errorText}</div>
        ) : null}

        <div style={{ marginTop: 16 }}>
          <div
            style={{
              border: "1px solid rgba(255,255,255,0.12)",
              background: "rgba(255,255,255,0.02)",
              borderRadius: 12,
              overflow: "auto",
            }}
          >
            <table style={{ width: "100%", borderCollapse: "collapse" }}>
              <thead>
                <tr style={{ textAlign: "left", fontSize: 13, opacity: 0.9 }}>
                  <th
                    style={{
                      padding: 10,
                      borderBottom: "1px solid rgba(255,255,255,0.10)",
                    }}
                  >
                    Cliente
                  </th>
                  <th
                    style={{
                      padding: 10,
                      borderBottom: "1px solid rgba(255,255,255,0.10)",
                    }}
                  >
                    Email
                  </th>
                  <th
                    style={{
                      padding: 10,
                      borderBottom: "1px solid rgba(255,255,255,0.10)",
                    }}
                  >
                    Prodotto
                  </th>
                  <th
                    style={{
                      padding: 10,
                      borderBottom: "1px solid rgba(255,255,255,0.10)",
                    }}
                  >
                    Prezzo
                  </th>
                  <th
                    style={{
                      padding: 10,
                      borderBottom: "1px solid rgba(255,255,255,0.10)",
                    }}
                  >
                    Messaggio
                  </th>
                  <th
                    style={{
                      padding: 10,
                      borderBottom: "1px solid rgba(255,255,255,0.10)",
                    }}
                  >
                    Data
                  </th>
                </tr>
              </thead>
              <tbody>
                {items.map((row) => (
                  <tr key={row.id}>
                    <td
                      style={{
                        padding: 10,
                        borderBottom: "1px solid rgba(255,255,255,0.06)",
                        fontWeight: 700,
                      }}
                    >
                      {row.customerName}
                    </td>
                    <td
                      style={{
                        padding: 10,
                        borderBottom: "1px solid rgba(255,255,255,0.06)",
                      }}
                    >
                      {row.customerEmail}
                    </td>
                    <td
                      style={{
                        padding: 10,
                        borderBottom: "1px solid rgba(255,255,255,0.06)",
                      }}
                    >
                      {row.productName}
                    </td>
                    <td
                      style={{
                        padding: 10,
                        borderBottom: "1px solid rgba(255,255,255,0.06)",
                      }}
                    >
                      {row.price}
                    </td>
                    <td
                      style={{
                        padding: 10,
                        borderBottom: "1px solid rgba(255,255,255,0.06)",
                        maxWidth: 520,
                      }}
                    >
                      {row.message}
                    </td>
                    <td
                      style={{
                        padding: 10,
                        borderBottom: "1px solid rgba(255,255,255,0.06)",
                      }}
                    >
                      {row.createdAt ? new Date(row.createdAt).toLocaleString() : "-"}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>

            {items.length === 0 && !isLoading ? (
              <div style={{ padding: 12, opacity: 0.85 }}>Nessun reclamo.</div>
            ) : null}
          </div>
        </div>
      </AppShell>
    </>
  );
}

