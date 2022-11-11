using System;
using BasicBilling.Core.Entities;
using BasicBilling.Core.Interfaces;

namespace BasicBilling.Infrastructure.Repositories
{
	public class BillRepository : IBillRepository
	{
		public async Task<IEnumerable<ClientBill>> GetPaidBillsByCategory(string category)
		{
			var bills = Enumerable.Range(1, 5).Select(i => new ClientBill
			{
				Id = i,
				BillId = i * 2,
				ClientId = 1,
				Status = BillStatus.Paid
			});

			await Task.Delay(10);
			return bills;
		}

    }
}

