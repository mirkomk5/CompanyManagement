import Head from "next/head";
import Link from "next/link";
import { AppShell } from "@/components/layout/AppShell";
import { useRequireAuth } from "@/components/auth/useRequireAuth";

function MacroCard(props: { title: string; description: string; href: string }) {
  return (
    <Link
      href={props.href}
      style={{
        display: "block",
        border: "1px solid rgba(255,255,255,0.12)",
        background: "rgba(255,255,255,0.04)",
        borderRadius: 12,
        padding: 16,
        color: "white",
        textDecoration: "none",
      }}
    >
      <div style={{ fontSize: 16, fontWeight: 700 }}>{props.title}</div>
      <div style={{ marginTop: 8, opacity: 0.9, fontSize: 13 }}>
        {props.description}
      </div>
    </Link>
  );
}

export function HomePage() {
  const { isReady, token } = useRequireAuth();
  if (!isReady || !token) return null;

  return (
    <>
      <Head>
        <title>Home - CompanyTest</title>
      </Head>

      <AppShell title="Home">
        <h1 style={{ marginTop: 0 }}>Home</h1>


        <div
          style={{
            display: "grid",
            gridTemplateColumns: "repeat(3, minmax(0, 1fr))",
            gap: 12,
          }}
        >
          <MacroCard
            title="Lista prodotti"
            description="Crea / modifica / elimina prodotti (CRUD)."
            href="/products"
          />
          <MacroCard
            title="Lista ordini"
            description="Dati tabellari via API con DTO (join / stored procedure)."
            href="/orders"
          />
          <MacroCard
            title="Lista reclami"
            description="Dati tabellari via API con DTO (join / stored procedure)."
            href="/claims"
          />
        </div>
      </AppShell>
    </>
  );
}

