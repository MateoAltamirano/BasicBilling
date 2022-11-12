using System;
using BasicBilling.Core.Entities;
using BasicBilling.Core.Interfaces;
using BasicBilling.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.Infrastructure.Repositories
{
	public class BillRepository : IBillRepository
	{
		private readonly BasicBillingContext _context;
		public BillRepository(BasicBillingContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ClientBill>> GetPaidBillsByCategory(string category)
		{
			var clientBills = await _context.ClientBill.Where(bill => bill.Bill!.Category == category).ToListAsync();
			return clientBills;
		}

        public async Task<IEnumerable<ClientBill>> GetPendingBillsByClientID(int clientID)
        {
            var clientBills = await _context.ClientBill.Where(bill => bill.ClientId == clientID).ToListAsync();
            return clientBills;
        }
		
        public async Task<ClientBill?> UpdateBillStatusToPaid(int clientBillID)
        {
            var clientBill = await _context.ClientBill.FirstAsync(clientBill => clientBill.Id == clientBillID);
			if (clientBill != null)
			{
                clientBill.Status = BillStatus.Paid;
				await _context.SaveChangesAsync();
			}
			return clientBill;
        }

		public async Task CreateBill(Bill bill)
		{
			await _context.Bill.AddAsync(bill);
			await _context.SaveChangesAsync();
		}

		public async Task CreateClientBill(ClientBill clientBill)
		{
			await _context.ClientBill.AddAsync(clientBill);
			await _context.SaveChangesAsync();
		}
    }
}

