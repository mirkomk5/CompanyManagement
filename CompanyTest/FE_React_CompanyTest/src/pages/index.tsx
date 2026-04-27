import { useEffect } from "react";
import { useRouter } from "next/router";
import Head from "next/head";
import { authStorage } from "@/api/authStorage";

export default function IndexPage() {
  const router = useRouter();

  useEffect(() => {
    // Pagina "ponte": se ho il token vado in home, altrimenti login.
    const token = authStorage.getToken();
    void router.replace(token ? "/home" : "/login");
  }, [router]);

  return (
    <>
      <Head>
        <title>CompanyTest</title>
      </Head>
      <main style={{ padding: 24 }}>Caricamento...</main>
    </>
  );
}
