using BasicBilling.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicBilling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BillingController : ControllerBase
    {
        private readonly IBillRepository _billRepository;
        public BillingController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
  
        [HttpGet("/search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaidBillsByCategory(string category)
        {
            var bills = await _billRepository.GetPaidBillsByCategory(category);
            return Ok(bills);
        }

        [HttpGet("/pending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPendingByClientID()
        {
            return Ok();
        }

        [HttpPost("/bills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateBill()
        {
            return Ok();
        }

        [HttpPost("/pay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreatePayment()
        {
            return Ok();
        }
    }
}