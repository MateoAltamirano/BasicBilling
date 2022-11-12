using System;
using BasicBilling.Core.Entities;

namespace BasicBilling.Core.Interfaces
{
	public interface IBillService
	{
        Task<IEnumerable<ClientBill>> GetPaymentsHistoryByCategory(string category);
        Task<IEnumerable<ClientBill>> GetPendingBillsFromClient(int clientID);
        Task CreateBill(Bill bill);
        Task AssignBill(ClientBill clientBill);
        Task<ClientBill> PayBill(int clientBillID);
    }
}