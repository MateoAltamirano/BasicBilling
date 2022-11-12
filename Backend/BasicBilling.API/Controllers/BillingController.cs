using AutoMapper;
using BasicBilling.Core.DTOs;
using BasicBilling.Core.Entities;
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
        private readonly IMapper _mapper;

        public BillingController(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }
  
        [HttpGet("/search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaymentsHistoryByCategory(string category)
        {
            var bills = await _billRepository.GetPaidBillsByCategory(category);
            return Ok(bills);
        }

        [HttpGet("/pending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPendingBillsFromClient(int clientID)
        {
            var bills = await _billRepository.GetPendingBillsByClientID(clientID);
            return Ok(bills);
        }

        [HttpPost("/bills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateBill(BillDTO billDTO)
        {
            var bill = _mapper.Map<Bill>(billDTO);
            await _billRepository.CreateBill(bill);
            return Created(string.Empty, bill);
        }

        [HttpPost("/pay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreatePayment()
        {
            return Ok();
        }
    }
}