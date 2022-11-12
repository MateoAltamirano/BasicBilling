using System;
using BasicBilling.Core.Entities;

namespace BasicBilling.Core.DTOs
{
	public class CreateClientBillDTO
	{
        public int Id { get; set; }
        public BillStatus Status { get; set; }
    }
}

