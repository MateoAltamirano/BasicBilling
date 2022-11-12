using System;
using BasicBilling.Core.DTOs;
using BasicBilling.Core.Entities;
using BasicBilling.Core.Exceptions;
using BasicBilling.Core.Interfaces;

namespace BasicBilling.Core.Services
{
	public class BillService : IBillService
	{
		private readonly IBillRepository _billRepository;
		public BillService(IBillRepository billRepository)
		{
			_billRepository = billRepository;
		}

        public async Task CreateBill(Bill bill)
        {
			try
			{
				await _billRepository.CreateBill(bill);
			}
			catch (Exception)
            {
				var message = BasicBillingExceptionMessages.SomethingWentWrong;
				var type = BasicBillingExceptionType.InternalServerError;
				throw new BasicBillingException(message, type);
			}
        }

        public async Task AssignBill(ClientBill clientBill)
        {
            try
            {
                await _billRepository.CreateClientBill(clientBill);
            }
            catch (Exception)
            {
                var message = BasicBillingExceptionMessages.SomethingWentWrong;
                var type = BasicBillingExceptionType.InternalServerError;
                throw new BasicBillingException(message, type);
            }
        }

        public Task<ClientBill> PayBill(int clientBillID)
        {
            var clientBill = _billRepository.UpdateBillStatusToPaid(clientBillID);
            if (clientBill != null)
            {
                throw new BasicBillingException(string.Format(BasicBillingExceptionMessages.NotFound, "Bill"), BasicBillingExceptionType.NotFound);
            }

            return clientBill!;
        }

        public Task<IEnumerable<ClientBill>> GetPaymentsHistoryByCategory(string category)
        {
            var clientBills = _billRepository.GetPaidBillsByCategory(category);
            return clientBills;
        }

        public Task<IEnumerable<ClientBill>> GetPendingBillsFromClient(int clientID)
        {
            var clientBills = _billRepository.GetPendingBillsByClientID(clientID);
            return clientBills;
        }
    }
}

