using System;
namespace BasicBilling.Core.Exceptions
{
	public class BasicBillingException : Exception
	{
		public BasicBillingException(string message, BasicBillingExceptionType type) : base(message)
		{
			Type = type;
		}

		public BasicBillingExceptionType Type { get; set; }
	}

    public enum BasicBillingExceptionType
    {
        BadRequest,
        Conflict,
		InternalServerError,
		NotFound
    }
}

