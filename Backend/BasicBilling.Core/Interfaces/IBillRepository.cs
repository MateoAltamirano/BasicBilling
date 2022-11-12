using BasicBilling.Core.Entities;

namespace BasicBilling.Core.Interfaces
{
	public interface IBillRepository
	{
		Task<IEnumerable<ClientBill>> GetPaidBillsByCategory(string category);
		Task<IEnumerable<ClientBill>> GetPendingBillsByClientID(int clientID);
		Task<ClientBill?> UpdateBillStatusToPaid(int clientBillID);
		Task CreateBill(Bill bill);
		Task CreateClientBill(ClientBill clientBill);
    }
}

