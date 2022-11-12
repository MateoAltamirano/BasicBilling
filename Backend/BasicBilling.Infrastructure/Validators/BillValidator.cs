using System;
using BasicBilling.Core.DTOs;
using FluentValidation;

namespace BasicBilling.Infrastructure.Validators
{
	public class BillValidator : AbstractValidator<BillDTO>
	{
		public BillValidator()
		{
			RuleFor(bill => bill.Category).NotNull();
			RuleFor(bill => bill.Period).NotNull();
		}
	}
}

