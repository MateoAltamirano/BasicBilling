export interface IBasicBillingErrorResponse {
  type: string;
  details: string[];
}

export interface IBasicBillingAPIResponse<T> {
  data: T;
  error: IBasicBillingErrorResponse;
}

export interface IClientBill {
  id: number;
  status: string;
}

export interface IBasicBillingState {
  billsByCategory: IClientBill[];
  fetchBillsByCategory: (
    category: string
  ) => Promise<IBasicBillingErrorResponse | null | undefined>;
  pendingBillsFromClient: IClientBill[];
  fetchPendingBillsFromClient: (
    clientID: string
  ) => Promise<IBasicBillingErrorResponse | null | undefined>;
  payBill: (
    billID: string
  ) => Promise<IBasicBillingErrorResponse | null | undefined>;
}
