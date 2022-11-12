using AutoMapper;
using BasicBilling.Core.DTOs;
using BasicBilling.Core.Entities;
using BasicBilling.Core.Interfaces;
using BasicBilling.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BasicBilling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BillingController : ControllerBase
    {
        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public BillingController(IBillService billService, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }
  
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaymentsHistoryByCategory(string category)
        {
            var clientBills = await _billService.GetPaymentsHistoryByCategory(category);
            var clientBillsResponse = clientBills.Select(clientBill => _mapper.Map<ClientBillDTO>(clientBill));
            var response = new APIResponse<IEnumerable<ClientBillDTO>>(clientBillsResponse, null);

            return Ok(response);
        }

        [HttpGet]
        [Route("pending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPendingBillsFromClient([FromQuery]int clientID)
        {
            var clientBills = await _billService.GetPendingBillsFromClient(clientID);
            var clientBillsResponse = clientBills.Select(clientBill => _mapper.Map<ClientBillDTO>(clientBill));
            var response = new APIResponse<IEnumerable<ClientBillDTO>>(clientBillsResponse, null);

            return Ok(response);
        }

        [HttpPost]
        [Route("bills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBill(BillDTO billDTO)
        {
            var bill = _mapper.Map<Bill>(billDTO);
            await _billService.CreateBill(bill);
            var createBillResponse = _mapper.Map<CreateBillDTO>(bill);
            var response = new APIResponse<CreateBillDTO>(createBillResponse, null);

            return Ok(response);
        }

        [HttpPost]
        [Route("assign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AssignBill(AssignBillDTO assignBillDTO)
        {
            var clientBill = _mapper.Map<ClientBill>(assignBillDTO);
            await _billService.AssignBill(clientBill);
            var createClientBillResponse = _mapper.Map<ClientBillDTO>(clientBill);
            var response = new APIResponse<ClientBillDTO>(createClientBillResponse, null);

            return Ok(response);
        }

        [HttpPost]
        [Route("pay/{clientBillID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PayBill(int clientBillID)
        {
            var clientBill = await _billService.PayBill(clientBillID);
            var clientBillResponse = _mapper.Map<ClientBillDTO>(clientBill);
            var response = new APIResponse<ClientBillDTO>(clientBillResponse, null);

            return Ok(response);
        }
    }
}