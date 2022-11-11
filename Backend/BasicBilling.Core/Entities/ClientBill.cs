using System;
namespace BasicBilling.Core.Entities
{
	public class ClientBill
	{
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BillId { get; set; }
        public BillStatus Status { get; set; }
    }

    public enum BillStatus
    {
        Pending,
        Paid
    }
}

