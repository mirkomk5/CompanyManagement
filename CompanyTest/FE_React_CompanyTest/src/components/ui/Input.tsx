import type { InputHTMLAttributes } from "react";

type Props = InputHTMLAttributes<HTMLInputElement> & {
  label: string;
  errorText?: string | null;
};

export function Input({ label, errorText, style, ...props }: Props) {
  return (
    <label style={{ display: "block" }}>
      <div style={{ fontSize: 13, opacity: 0.9, marginBottom: 6 }}>{label}</div>
      <input
        {...props}
        style={{
          width: "100%",
          padding: "10px 12px",
          borderRadius: 8,
          border: "1px solid rgba(255,255,255,0.14)",
          background: "rgba(255,255,255,0.06)",
          color: "white",
          outline: "none",
          ...style,
        }}
      />
      {errorText ? (
        <div style={{ color: "#ffb4b4", fontSize: 12, marginTop: 6 }}>
          {errorText}
        </div>
      ) : null}
    </label>
  );
}

