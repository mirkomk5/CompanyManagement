import { useEffect, useState } from "react";
import { useRouter } from "next/router";
import { authStorage } from "@/api/authStorage";

export function useRequireAuth() {
  const router = useRouter();
  const [isReady, setIsReady] = useState(false);
  const [token, setToken] = useState<string | null>(null);

  useEffect(() => {
    const storedToken = authStorage.getToken();
    setToken(storedToken);
    setIsReady(true);

    if (!storedToken) {
      // Non facciamo cose "strane": se manca il token, torno al login.
      void router.replace("/login");
    }
  }, [router]);

  return { isReady, token };
}

