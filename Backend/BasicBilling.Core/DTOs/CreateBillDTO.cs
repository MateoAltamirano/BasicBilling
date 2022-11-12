using System;
using BasicBilling.Core.Entities;

namespace BasicBilling.Core.DTOs
{
	public class CreateBillDTO
	{
        public int Id { get; set; }
        public string? Category { get; set; }
        public int Period { get; set; }
    }
}

