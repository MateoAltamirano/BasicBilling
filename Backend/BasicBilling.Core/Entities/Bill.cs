using System;
namespace BasicBilling.Core.Entities
{
	public class Bill
	{
        public Bill()
        {
            ClientBills = new HashSet<ClientBill>();
        }

        public int Id { get; set; }
        public string? Category { get; set; }
		public int Period { get; set; }

        public virtual ICollection<ClientBill> ClientBills { get; set; }
    }
}