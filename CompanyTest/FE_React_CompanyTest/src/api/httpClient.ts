import { authStorage } from "@/api/authStorage";
import { buildApiUrl } from "@/api/config";

export class ApiError extends Error {
  status: number;
  bodyText?: string;

  constructor(message: string, status: number, bodyText?: string) {
    super(message);
    this.name = "ApiError";
    this.status = status;
    this.bodyText = bodyText;
  }
}

type HttpMethod = "GET" | "POST" | "PATCH" | "DELETE";

async function tryReadText(response: Response) {
  try {
    return await response.text();
  } catch {
    return undefined;
  }
}

export async function httpRequest<TResponse>(args: {
  method: HttpMethod;
  path: string;
  body?: unknown;
  token?: string | null;
}): Promise<TResponse> {
  const token = args.token ?? authStorage.getToken();

  const headers: Record<string, string> = {
    Accept: "application/json",
  };

  // Se c'è un body, diciamo che è JSON.
  if (args.body !== undefined) {
    headers["Content-Type"] = "application/json";
  }

  if (token) {
    headers.Authorization = `Bearer ${token}`;
  }

  const response = await fetch(buildApiUrl(args.path), {
    method: args.method,
    headers,
    body: args.body !== undefined ? JSON.stringify(args.body) : undefined,
  });

  if (!response.ok) {
    const bodyText = await tryReadText(response);
    
    throw new ApiError(
      `Errore API (${response.status})`,
      response.status,
      bodyText
    );
  }

  // Alcune API potrebbero rispondere con stringa/ok vuoto.
  const text = await response.text();
  if (!text) return undefined as unknown as TResponse;

  try {
    return JSON.parse(text) as TResponse;
  } catch {
    // Se non è JSON, lo ritorno come testo.
    return text as unknown as TResponse;
  }
}

