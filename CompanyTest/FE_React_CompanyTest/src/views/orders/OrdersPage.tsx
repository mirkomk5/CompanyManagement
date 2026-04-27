import Head from "next/head";
import { useEffect, useState } from "react";
import { ordersApi } from "@/api/ordersApi";
import { ApiError } from "@/api/httpClient";
import type { OrderTableDto } from "@/dto/orderDto";
import { AppShell } from "@/components/layout/AppShell";
import { useRequireAuth } from "@/components/auth/useRequireAuth";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";

export function OrdersPage() {
  const { isReady, token } = useRequireAuth();

  const [from, setFrom] = useState("1");
  const [amount, setAmount] = useState("10");

  const [items, setItems] = useState<OrderTableDto[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [errorText, setErrorText] = useState<string | null>(null);

  const load = async () => {
    setErrorText(null);
    setIsLoading(true);
    try {
      const result = await ordersApi.getOrdersTable({
        from: Number(from),
        amount: Number(amount),
      });
      setItems(result ?? []);
    } catch (error) {
      if (error instanceof ApiError) {
        setErrorText(
          error.bodyText ??
            "Errore nel caricamento ordini. (Possibile: token non valido o CORS)."
        );
      } else {
        setErrorText("Errore nel caricamento ordini.");
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
        <title>Ordini - CompanyTest</title>
      </Head>

      <AppShell title="Ordini">
        <h1 style={{ marginTop: 0, marginBottom: 6 }}>Lista ordini</h1>
        <div style={{ opacity: 0.85, fontSize: 13 }}>
          Questa schermata usa l'endpoint che ritorna un DTO "tabellare" (join /
          stored procedure): `GET v1/Orders/ordersTable/{from}/{amount}`
        </div>

        <div
          style={{
            display: "flex",
            alignItems: "end",
            gap: 12,
            marginTop: 14,
          }}
        >
          <div style={{ width: 140 }}>
            <Input
              label="From (pagina)"
              inputMode="numeric"
              value={from}
              onChange={(e) => setFrom(e.target.value)}
            />
          </div>
          <div style={{ width: 140 }}>
            <Input
              label="Amount (righe)"
              inputMode="numeric"
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
            />
          </div>
          <Button variant="secondary" onClick={load} disabled={isLoading}>
            {isLoading ? "Carico..." : "Carica"}
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
                  <th style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.10)" }}>
                    OrderId
                  </th>
                  <th style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.10)" }}>
                    Data
                  </th>
                  <th style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.10)" }}>
                    Cliente
                  </th>
                  <th style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.10)" }}>
                    Indirizzo
                  </th>
                  <th style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.10)" }}>
                    Prodotto
                  </th>
                  <th style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.10)" }}>
                    Prezzo
                  </th>
                  <th style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.10)" }}>
                    Note
                  </th>
                </tr>
              </thead>
              <tbody>
                {items.map((row) => (
                  <tr key={`${row.orderId}-${row.productName}`}>
                    <td style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.06)" }}>
                      {row.orderId}
                    </td>
                    <td style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.06)" }}>
                      {row.orderDate ? new Date(row.orderDate).toLocaleString() : "-"}
                    </td>
                    <td style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.06)" }}>
                      {row.customerFullname}
                    </td>
                    <td style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.06)" }}>
                      {row.address}
                    </td>
                    <td style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.06)" }}>
                      {row.productName}
                    </td>
                    <td style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.06)" }}>
                      {row.price}
                    </td>
                    <td style={{ padding: 10, borderBottom: "1px solid rgba(255,255,255,0.06)" }}>
                      {row.notes}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>

            {items.length === 0 && !isLoading ? (
              <div style={{ padding: 12, opacity: 0.85 }}>
                Nessun ordine (o parametri troppo stretti).
              </div>
            ) : null}
          </div>
        </div>
      </AppShell>
    </>
  );
}

