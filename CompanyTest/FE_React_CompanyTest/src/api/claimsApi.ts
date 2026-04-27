import { httpRequest } from "@/api/httpClient";
import type { ClaimsTableDto } from "@/dto/claimsDto";

export const claimsApi = {
  async getClaimsTable() {
    return await httpRequest<ClaimsTableDto[]>({
      method: "POST",
      path: "/v1/Claims/claims-table",
    });
  },
};

