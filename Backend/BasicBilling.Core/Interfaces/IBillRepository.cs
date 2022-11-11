using BasicBilling.Core.Entities;

namespace BasicBilling.Core.Interfaces
{
	public interface IBillRepository
	{
		Task<IEnumerable<ClientBill>> GetPaidBillsByCategory(string category);
	}
}

