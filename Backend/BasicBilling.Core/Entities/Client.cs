using System;
namespace BasicBilling.Core.Entities
{
	public class Client
	{
		public Client()
		{
			Bills = new HashSet<ClientBill>();
		}

        public int Id { get; set; }
        public string? Name { get; set; }

		public virtual ICollection<ClientBill> Bills { get; set; }
	}
}