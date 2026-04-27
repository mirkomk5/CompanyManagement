import Head from "next/head";
import { useEffect, useMemo, useState } from "react";
import { productsApi } from "@/api/productsApi";
import { ApiError } from "@/api/httpClient";
import type { ProductDto } from "@/dto/productDto";
import { AppShell } from "@/components/layout/AppShell";
import { useRequireAuth } from "@/components/auth/useRequireAuth";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";

function ProductForm(props: {
  mode: "create" | "edit";
  initial?: ProductDto | null;
  onCancel: () => void;
  onSave: (product: ProductDto) => Promise<void>;
}) {
  const initial = props.initial ?? null;

  const [productName, setProductName] = useState(initial?.productName ?? "");
  const [description, setDescription] = useState(initial?.description ?? "");
  const [price, setPrice] = useState(String(initial?.price ?? 0));
  const [discount, setDiscount] = useState(
    initial?.discount === null || initial?.discount === undefined
      ? ""
      : String(initial.discount)
  );

  const [errorText, setErrorText] = useState<string | null>(null);
  const [isSaving, setIsSaving] = useState(false);

  const title = props.mode === "create" ? "Nuovo prodotto" : "Modifica prodotto";

  const onSubmit = async () => {
    setErrorText(null);

    const parsedPrice = Number(price);
    const parsedDiscount = discount.trim() === "" ? null : Number(discount);

    if (!productName.trim()) {
      setErrorText("Il nome prodotto è obbligatorio.");
      return;
    }
    if (Number.isNaN(parsedPrice)) {
      setErrorText("Il prezzo non è valido.");
      return;
    }
    if (parsedDiscount !== null && Number.isNaN(parsedDiscount)) {
      setErrorText("Lo sconto non è valido.");
      return;
    }

    setIsSaving(true);
    try {
      await props.onSave({
        id: initial?.id ?? null,
        productName: productName.trim(),
        description: description.trim() ? description.trim() : null,
        price: parsedPrice,
        discount: parsedDiscount,
      });
    } finally {
      setIsSaving(false);
    }
  };

  return (
    <div
      style={{
        border: "1px solid rgba(255,255,255,0.12)",
        background: "rgba(255,255,255,0.04)",
        borderRadius: 12,
        padding: 16,
      }}
    >
      <div style={{ display: "flex", justifyContent: "space-between", gap: 12 }}>
        <div>
          <div style={{ fontWeight: 800, fontSize: 16 }}>{title}</div>
          <div style={{ opacity: 0.85, fontSize: 13, marginTop: 6 }}>
            {props.mode === "create"
              ? "Crea un nuovo prodotto e salvalo."
              : "Modifica i campi e salva."}
          </div>
        </div>
        <Button variant="secondary" onClick={props.onCancel}>
          Chiudi
        </Button>
      </div>

      <div style={{ display: "grid", gap: 12, marginTop: 14 }}>
        <Input
          label="Nome prodotto"
          value={productName}
          onChange={(e) => setProductName(e.target.value)}
          placeholder="Es. Mouse"
        />
        <Input
          label="Descrizione (opzionale)"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          placeholder="Testo libero..."
        />
        <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr", gap: 12 }}>
          <Input
            label="Prezzo"
            inputMode="decimal"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
          />
          <Input
            label="Sconto (opzionale)"
            inputMode="decimal"
            value={discount}
            onChange={(e) => setDiscount(e.target.value)}
            placeholder="Es. 5"
          />
        </div>

        {errorText ? (
          <div style={{ color: "#ffb4b4", fontSize: 13 }}>{errorText}</div>
        ) : null}

        <div style={{ display: "flex", gap: 10 }}>
          <Button disabled={isSaving} onClick={onSubmit}>
            {isSaving ? "Salvataggio..." : "Salva"}
          </Button>
        </div>
      </div>
    </div>
  );
}

export function ProductsPage() {
  const { isReady, token } = useRequireAuth();

  const [items, setItems] = useState<ProductDto[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [errorText, setErrorText] = useState<string | null>(null);

  const [formMode, setFormMode] = useState<"create" | "edit" | null>(null);
  const [selectedProduct, setSelectedProduct] = useState<ProductDto | null>(null);

  const sortedItems = useMemo(() => {
    return [...items].sort((a, b) =>
      a.productName.localeCompare(b.productName, "it")
    );
  }, [items]);

  const load = async () => {
    setErrorText(null);
    setIsLoading(true);
    try {
      const result = await productsApi.getAll();
      setItems(result ?? []);
    } catch (error) {
      if (error instanceof ApiError) {
        setErrorText(
          error.bodyText ??
            "Errore nel caricamento prodotti. (Possibile: token non valido o CORS)."
        );
      } else {
        setErrorText("Errore nel caricamento prodotti.");
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

  const onCreate = () => {
    setSelectedProduct(null);
    setFormMode("create");
  };

  const onEdit = (product: ProductDto) => {
    setSelectedProduct(product);
    setFormMode("edit");
  };

  const onDelete = async (product: ProductDto) => {
    if (!product.id) return;
    const ok = window.confirm(
      `Sei sicuro di eliminare "${product.productName}"?`
    );
    if (!ok) return;

    try {
      await productsApi.deleteById(product.id);
      await load();
    } catch (error) {
      if (error instanceof ApiError) {
        alert(error.bodyText ?? "Errore durante l'eliminazione.");
      } else {
        alert("Errore durante l'eliminazione.");
      }
    }
  };

  const onSave = async (product: ProductDto) => {
    try {
      if (formMode === "create") {
        await productsApi.create(product);
      } else {
        await productsApi.update(product);
      }
      setFormMode(null);
      setSelectedProduct(null);
      await load();
    } catch (error) {
      if (error instanceof ApiError) {
        alert(error.bodyText ?? "Errore durante il salvataggio.");
      } else {
        alert("Errore durante il salvataggio.");
      }
    }
  };

  if (!isReady || !token) return null;

  return (
    <>
      <Head>
        <title>Prodotti - CompanyTest</title>
      </Head>

      <AppShell title="Prodotti">
        <div
          style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            gap: 12,
          }}
        >
          <div>
            <h1 style={{ marginTop: 0, marginBottom: 6 }}>Lista prodotti</h1>
            <div style={{ opacity: 0.85, fontSize: 13 }}>
              CRUD su `v1/Products` (create / update / delete / get-all).
            </div>
          </div>
          <div style={{ display: "flex", gap: 10 }}>
            <Button variant="secondary" onClick={load} disabled={isLoading}>
              {isLoading ? "Aggiorno..." : "Aggiorna"}
            </Button>
            <Button onClick={onCreate}>Nuovo</Button>
          </div>
        </div>

        {errorText ? (
          <div style={{ color: "#ffb4b4", marginTop: 12 }}>{errorText}</div>
        ) : null}

        {formMode ? (
          <div style={{ marginTop: 16 }}>
            <ProductForm
              mode={formMode}
              initial={selectedProduct}
              onCancel={() => {
                setFormMode(null);
                setSelectedProduct(null);
              }}
              onSave={onSave}
            />
          </div>
        ) : null}

        <div style={{ marginTop: 16 }}>
          <div
            style={{
              border: "1px solid rgba(255,255,255,0.12)",
              background: "rgba(255,255,255,0.02)",
              borderRadius: 12,
              overflow: "hidden",
            }}
          >
            <div
              style={{
                display: "grid",
                gridTemplateColumns: "2fr 2fr 1fr 1fr 160px",
                gap: 0,
                padding: "10px 12px",
                borderBottom: "1px solid rgba(255,255,255,0.10)",
                fontSize: 13,
                opacity: 0.9,
              }}
            >
              <div>Nome</div>
              <div>Descrizione</div>
              <div>Prezzo</div>
              <div>Sconto</div>
              <div style={{ textAlign: "right" }}>Azioni</div>
            </div>

            {sortedItems.map((p) => (
              <div
                key={p.id ?? `${p.productName}-${p.price}`}
                style={{
                  display: "grid",
                  gridTemplateColumns: "2fr 2fr 1fr 1fr 160px",
                  padding: "10px 12px",
                  borderBottom: "1px solid rgba(255,255,255,0.06)",
                  alignItems: "center",
                  gap: 0,
                }}
              >
                <div style={{ fontWeight: 700 }}>{p.productName}</div>
                <div style={{ opacity: 0.9, fontSize: 13 }}>
                  {p.description ?? "-"}
                </div>
                <div>{p.price}</div>
                <div>{p.discount ?? "-"}</div>
                <div style={{ display: "flex", gap: 10, justifyContent: "flex-end" }}>
                  <Button variant="secondary" onClick={() => onEdit(p)}>
                    Modifica
                  </Button>
                  <Button variant="danger" onClick={() => onDelete(p)}>
                    Elimina
                  </Button>
                </div>
              </div>
            ))}

            {sortedItems.length === 0 && !isLoading ? (
              <div style={{ padding: 12, opacity: 0.85 }}>Nessun prodotto.</div>
            ) : null}
          </div>
        </div>
      </AppShell>
    </>
  );
}

