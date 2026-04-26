import Head from "next/head";
import Link from "next/link";
import { useRouter } from "next/router";
import { useState } from "react";
import { authApi } from "@/api/authApi";
import { authStorage } from "@/api/authStorage";
import { ApiError } from "@/api/httpClient";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";

export function LoginPage() {
  const router = useRouter();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorText, setErrorText] = useState<string | null>(null);
  const [isSubmitting, setIsSubmitting] = useState(false);

  const onSubmit = async () => {
    setErrorText(null);
    setIsSubmitting(true);
    try {
      const response = await authApi.login({ email, password });
      if (!response?.success || !response?.tokenId) {
        setErrorText(response?.message ?? "Login non riuscito.");
        return;
      }

      authStorage.setToken(response.tokenId);
      authStorage.setUserId(response.userId);
      void router.push("/home");
    } catch (error) {
      if (error instanceof ApiError) {
        setErrorText(error.bodyText ?? "Errore durante il login.");
      } else {
        setErrorText("Errore durante il login.");
      }
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <>
      <Head>
        <title>Login - CompanyTest</title>
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
            maxWidth: 420,
            border: "1px solid rgba(255,255,255,0.12)",
            background: "rgba(255,255,255,0.04)",
            borderRadius: 12,
            padding: 18,
          }}
        >
          <h1 style={{ margin: 0, marginBottom: 14 }}>Login</h1>

          <div style={{ display: "grid", gap: 12 }}>
            <Input
              label="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              autoComplete="email"
              placeholder="inserisci email..."
            />
            <Input
              label="Password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              autoComplete="current-password"
              placeholder="********"
            />

            {errorText ? (
              <div style={{ color: "#ffb4b4", fontSize: 13 }}>{errorText}</div>
            ) : null}

            <Button disabled={isSubmitting} onClick={onSubmit}>
              {isSubmitting ? "Accesso..." : "Accedi"}
            </Button>

            <div style={{ fontSize: 13, opacity: 0.9 }}>
              Non hai un account?{" "}
              <Link href="/register" style={{ color: "white" }}>
                Registrati
              </Link>
            </div>
          </div>
        </div>
      </main>
    </>
  );
}

