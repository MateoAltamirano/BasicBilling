using System;
namespace BasicBilling.Core.Responses
{
	public class APIResponse<T>
	{
		public APIResponse(T? data, ErrorResponse? error)
		{
			Data = data;
			Error = error;
		}

		public T? Data { get; set; }
		public ErrorResponse? Error { get; set; }
	}
}

