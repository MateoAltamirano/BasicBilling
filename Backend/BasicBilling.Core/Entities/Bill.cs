using System;
namespace BasicBilling.Core.Entities
{
	public class Bill
	{
        public int Id { get; set; }
        public string? Category { get; set; }
		public int Period { get; set; }
    }
}