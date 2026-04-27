import type { ButtonHTMLAttributes, PropsWithChildren } from "react";

type Props = PropsWithChildren<
  ButtonHTMLAttributes<HTMLButtonElement> & {
    variant?: "primary" | "secondary" | "danger";
  }
>;

export function Button({ variant = "primary", style, ...props }: Props) {
  const background =
    variant === "primary"
      ? "#1f6feb"
      : variant === "danger"
        ? "#cf222e"
        : "#30363d";

  return (
    <button
      {...props}
      style={{
        border: "1px solid rgba(255,255,255,0.12)",
        background,
        color: "white",
        padding: "10px 12px",
        borderRadius: 8,
        cursor: props.disabled ? "not-allowed" : "pointer",
        opacity: props.disabled ? 0.7 : 1,
        ...style,
      }}
    />
  );
}

