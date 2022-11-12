using System;
using BasicBilling.Core.Exceptions;

namespace BasicBilling.Core.Responses
{
	public class ErrorResponse
	{
		public ErrorResponse()
		{
			Type = BasicBillingExceptionType.InternalServerError.ToString();
			Details = new List<string>
			{
				BasicBillingExceptionMessages.SomethingWentWrong
			};
		}

		public string Type { get; set; }
		public IEnumerable<string> Details { get; set; }
	}
}

