import create from 'zustand';
import axios from 'axios';
import {
  IBasicBillingAPIResponse,
  IBasicBillingErrorResponse,
  IBasicBillingState,
  IClientBill,
} from './interfaces';

export const useBasicBillingStore = create<IBasicBillingState>()((set) => ({
  billsByCategory: [],
  fetchBillsByCategory: async (category) => {
    if (category) {
      try {
        const { data } = await axios.get<
          IBasicBillingAPIResponse<IClientBill[]>
        >(
          `${
            import.meta.env.VITE_BASIC_BILLING_API_URL
          }/search?category=${category}`,
          {
            headers: {
              Accept: 'application/json',
            },
          }
        );
        if (data.error !== null) {
          return data.error;
        }
        const clientBills = data.data;
        set(() => ({ billsByCategory: clientBills }));
      } catch (error) {
        return {
          type: 'InternalServerError',
          details: ['Something went wrong.'],
        };
      }
    } else {
      set(() => ({ billsByCategory: [] }));
    }
  },
  pendingBillsFromClient: [],
  fetchPendingBillsFromClient: async (clientID) => {
    try {
      const { data } = await axios.get<IBasicBillingAPIResponse<IClientBill[]>>(
        `${
          import.meta.env.VITE_BASIC_BILLING_API_URL
        }/pending?clientID=${clientID}`,
        {
          headers: {
            Accept: 'application/json',
          },
        }
      );
      if (data.error !== null) {
        return data.error;
      }
      const clientBills = data.data;
      set(() => ({ pendingBillsFromClient: clientBills }));
    } catch (error) {
      if (axios.isAxiosError(error)) {
        const { type, details } = error.response?.data
          .error as IBasicBillingErrorResponse;
        return {
          type,
          details,
        };
      }
      return {
        type: 'InternalServerError',
        details: ['Something went wrong.'],
      };
    }
  },
  payBill: async (billID) => {
    try {
      const { data } = await axios.post<IBasicBillingAPIResponse<IClientBill>>(
        `${import.meta.env.VITE_BASIC_BILLING_API_URL}/pay/${billID}`,
        {
          headers: {
            Accept: 'application/json',
          },
        }
      );
      if (data.error !== null) {
        return data.error;
      }
      set((state) => ({
        pendingBillsFromClient: state.pendingBillsFromClient.filter(
          (bill) => bill.id !== parseInt(billID)
        ),
      }));
    } catch (error) {
      if (axios.isAxiosError(error)) {
        const { type, details } = error.response?.data
          .error as IBasicBillingErrorResponse;
        return {
          type,
          details,
        };
      }
      return {
        type: 'InternalServerError',
        details: ['Something went wrong.'],
      };
    }
  },
}));
