import { httpRequest } from "@/api/httpClient";
import type { ProductDto } from "@/dto/productDto";

export const productsApi = {
  async getAll() {
    return await httpRequest<ProductDto[]>({
      method: "GET",
      path: "/v1/Products/get-all",
    });
  },
  async create(product: ProductDto) {
    return await httpRequest<ProductDto>({
      method: "POST",
      path: "/v1/Products/create",
      body: product,
    });
  },
  async update(product: ProductDto) {
    return await httpRequest<ProductDto>({
      method: "PATCH",
      path: "/v1/Products/update",
      body: product,
    });
  },
  async deleteById(id: string) {
    return await httpRequest<unknown>({
      method: "DELETE",
      path: `/v1/Products/delete/${encodeURIComponent(id)}`,
    });
  },
};

