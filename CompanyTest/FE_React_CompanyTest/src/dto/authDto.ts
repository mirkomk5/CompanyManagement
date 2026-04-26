export type AuthRequestDto = {
  email: string;
  password: string;
};

export type RegisterRequestDto = {
  email: string;
  name: string;
  surname: string;
  password: string;
  address?: string | null;
};

export type AuthResponseDto = {
  userId: string;
  tokenId: string;
  message?: string | null;
  success?: boolean | null;
};

