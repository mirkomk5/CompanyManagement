import Head from "next/head";
import Link from "next/link";
import { useRouter } from "next/router";
import { useState } from "react";
import { authApi } from "@/api/authApi";
import { authStorage } from "@/api/authStorage";
import { ApiError } from "@/api/httpClient";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";

export function RegisterPage() {
  const router = useRouter();
  const [email, setEmail] = useState("");
  const [name, setName] = useState("");
  const [surname, setSurname] = useState("");
  const [address, setAddress] = useState("");
  const [password, setPassword] = useState("");
  const [errorText, setErrorText] = useState<string | null>(null);
  const [isSubmitting, setIsSubmitting] = useState(false);

  const onSubmit = async () => {
    setErrorText(null);
    setIsSubmitting(true);
    try {
      const response = await authApi.register({
        email,
        name,
        surname,
        password,
        address: address ? address : null,
      });

      if (!response?.success || !response?.tokenId) {
        setErrorText(response?.message ?? "Registrazione non riuscita.");
        return;
      }

      // Scelta semplice: dopo registrazione salvo token e vado in home.
      authStorage.setToken(response.tokenId);
      authStorage.setUserId(response.userId);
      void router.push("/home");
    } catch (error) {
      if (error instanceof ApiError) {
        setErrorText(error.bodyText ?? "Errore durante la registrazione.");
      } else {
        setErrorText("Errore durante la registrazione.");
      }
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <>
      <Head>
        <title>Registrazione - CompanyTest</title>
      </Head>

      <main
        style={{
          minHeight: "100vh",
          display: "grid",
          placeItems: "center",
          padding: 18,
        }}
      >
        <div
          style={{
            width: "100%",
            maxWidth: 520,
            border: "1px solid rgba(255,255,255,0.12)",
            background: "rgba(255,255,255,0.04)",
            borderRadius: 12,
            padding: 18,
          }}
        >
          <h1 style={{ margin: 0, marginBottom: 14 }}>Registrazione</h1>

          <div style={{ display: "grid", gap: 12 }}>
            <Input
              label="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              autoComplete="email"
              placeholder="esempio@email.it"
            />
            <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr", gap: 12 }}>
              <Input
                label="Nome"
                value={name}
                onChange={(e) => setName(e.target.value)}
                autoComplete="given-name"
              />
              <Input
                label="Cognome"
                value={surname}
                onChange={(e) => setSurname(e.target.value)}
                autoComplete="family-name"
              />
            </div>
            <Input
              label="Indirizzo (opzionale)"
              value={address}
              onChange={(e) => setAddress(e.target.value)}
              autoComplete="street-address"
              placeholder="Via ..."
            />
            <Input
              label="Password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              autoComplete="new-password"
              placeholder="********"
            />

            {errorText ? (
              <div style={{ color: "#ffb4b4", fontSize: 13 }}>{errorText}</div>
            ) : null}

            <Button disabled={isSubmitting} onClick={onSubmit}>
              {isSubmitting ? "Creazione..." : "Crea account"}
            </Button>

            <div style={{ fontSize: 13, opacity: 0.9 }}>
              Hai già un account?{" "}
              <Link href="/login" style={{ color: "white" }}>
                Vai al login
              </Link>
            </div>
          </div>
        </div>
      </main>
    </>
  );
}

