using System;
using BasicBilling.Core.Entities;

namespace BasicBilling.Core.DTOs
{
	public class ClientBillDTO
	{
        public int Id { get; set; }
        public BillStatus Status { get; set; }
    }
}

