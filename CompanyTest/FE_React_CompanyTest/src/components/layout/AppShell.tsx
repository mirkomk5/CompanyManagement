import Link from "next/link";
import { useRouter } from "next/router";
import type { PropsWithChildren } from "react";
import { authStorage } from "@/api/authStorage";
import { Button } from "@/components/ui/Button";

export function AppShell(props: PropsWithChildren<{ title: string }>) {
  const router = useRouter();

  const onLogout = () => {
    // Logout molto "terra terra": cancello token e torno al login.
    authStorage.clearAll();
    void router.push("/login");
  };

  return (
    <div style={{ minHeight: "100vh" }}>
      <header
        style={{
          position: "sticky",
          top: 0,
          zIndex: 5,
          backdropFilter: "blur(10px)",
          background: "rgba(9, 12, 18, 0.75)",
          borderBottom: "1px solid rgba(255,255,255,0.10)",
        }}
      >
        <div
          style={{
            maxWidth: 1100,
            margin: "0 auto",
            padding: "14px 16px",
            display: "flex",
            alignItems: "center",
            gap: 12,
            justifyContent: "space-between",
          }}
        >
          <div style={{ display: "flex", alignItems: "center", gap: 12 }}>
            <Link href="/home" style={{ color: "white", fontWeight: 700 }}>
              CompanyTest
            </Link>
            <nav style={{ display: "flex", gap: 10, opacity: 0.95 }}>
              <Link href="/products" style={{ color: "white" }}>
                Prodotti
              </Link>
              <Link href="/orders" style={{ color: "white" }}>
                Ordini
              </Link>
              <Link href="/claims" style={{ color: "white" }}>
                Reclami
              </Link>
            </nav>
          </div>

          <div style={{ display: "flex", alignItems: "center", gap: 10 }}>
            <div style={{ opacity: 0.85, fontSize: 13 }}>{props.title}</div>
            <Button variant="secondary" onClick={onLogout}>
              Logout
            </Button>
          </div>
        </div>
      </header>

      <main style={{ maxWidth: 1100, margin: "0 auto", padding: "18px 16px" }}>
        {props.children}
      </main>
    </div>
  );
}

