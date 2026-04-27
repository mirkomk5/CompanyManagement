import { httpRequest } from "@/api/httpClient";
import type { OrderTableDto } from "@/dto/orderDto";

export const ordersApi = {
  async getOrdersTable(args: { from: number; amount: number }) {
    return await httpRequest<OrderTableDto[]>({
      method: "GET",
      path: `/v1/Orders/ordersTable/${args.from}/${args.amount}`,
    });
  },
};

