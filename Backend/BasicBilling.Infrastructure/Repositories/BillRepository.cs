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
			var bills = await _context.ClientBill.Where(bill => bill.Bill!.Category == category).ToListAsync();
			return bills;
		}

        public async Task<IEnumerable<ClientBill>> GetPendingBillsByClientID(int clientID)
        {
            var bills = await _context.ClientBill.Where(bill => bill.ClientId == clientID).ToListAsync();
            return bills;
        }
		
        public async Task<ClientBill?> UpdateBillStatusToPaid(int clientBillID)
        {
            var bill = await _context.ClientBill.FirstAsync(bill => bill.Id == clientBillID);
			if (bill != null)
			{
				bill.Status = BillStatus.Paid;
				await _context.SaveChangesAsync();
			}
			return bill;
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

		public async Task<Bill?> GetBillByID(int billID)
		{
			var bill = await _context.Bill.FirstAsync(bill => bill.Id == billID);
			return bill;
		}
    }
}

