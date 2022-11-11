using Microsoft.AspNetCore.Mvc;

namespace BasicBilling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BillingController : ControllerBase
    {
  
        [HttpGet("/search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetHistoryByCategory()
        {
            return Ok();
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