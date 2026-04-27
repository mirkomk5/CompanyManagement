export type OrderTableDto = {
  orderId: string;
  orderDate?: string | null;
  customerFullname: string;
  address: string;
  productName: string;
  price: number;
  notes: string;
};

