import { httpRequest } from "@/api/httpClient";
import type {
  AuthRequestDto,
  AuthResponseDto,
  RegisterRequestDto,
} from "@/dto/authDto";

export const authApi = {
  async login(request: AuthRequestDto) {
    return await httpRequest<AuthResponseDto>({
      method: "POST",
      path: "/v1/Auth/login",
      body: request,
    });
  },
  async register(request: RegisterRequestDto) {
    return await httpRequest<AuthResponseDto>({
      method: "POST",
      path: "/v1/Auth/register",
      body: request,
    });
  },
};

