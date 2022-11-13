using AutoMapper;
using BasicBilling.Core.Entities;
using BasicBilling.Core.Exceptions;
using BasicBilling.Core.Interfaces;
using BasicBilling.Core.Services;
using BasicBilling.Infrastructure.Mappings;
using Moq;

namespace BasicBilling.UnitTests;

public class BillServiceTests
{
    private readonly IBillService _billService;
    private readonly Mock<IBillRepository> _mockRepository;
    private readonly IMapper _mapper;

    public BillServiceTests()
    {
        _mockRepository = new Mock<IBillRepository>();
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        }).CreateMapper();
        _billService = new BillService(_mockRepository.Object);
    }

    [Fact]
    public async void GetPendingBillsFromClient_ReturnsBills()
    {
        //Arrange
        var clientID = 1;
        var clientBill1 = new ClientBill { Id = 1, BillId = 1, ClientId = clientID, Status = BillStatus.Pending };
        var clientBill2 = new ClientBill { Id = 2, BillId = 2, ClientId = clientID, Status = BillStatus.Pending };

        var clientBills = new List<ClientBill> { clientBill1, clientBill2 };
        _mockRepository.Setup(x => x.GetPendingBillsByClientID(clientID)).ReturnsAsync(clientBills);

        //Act
        var result = await _billService.GetPendingBillsFromClient(clientID);

        //Assert
        Assert.Equal(result, clientBills);
    }

    [Fact]
    public async void GetPaymentsHistoryByCategory_ReturnsBills()
    {
        //Arrange
        var category = "WATER";
        var clientBill1 = new ClientBill { Id = 1, BillId = 1, ClientId = 1, Status = BillStatus.Paid };
        var clientBill2 = new ClientBill { Id = 2, BillId = 2, ClientId = 2, Status = BillStatus.Paid };

        var clientBills = new List<ClientBill> { clientBill1, clientBill2 };
        _mockRepository.Setup(x => x.GetPaidBillsByCategory(category)).ReturnsAsync(clientBills);

        //Act
        var result = await _billService.GetPaymentsHistoryByCategory(category);

        //Assert
        Assert.Equal(result, clientBills);
    }

    [Fact]
    public void PayBill_ThrowsAlgorithmyaException()
    {
        //Arrange
        var clientBillID = 1;
        ClientBill? clientBill = null;
        _mockRepository.Setup(x => x.UpdateBillStatusToPaid(clientBillID)).ReturnsAsync(clientBill);

        //Act
        //Assert
        Assert.ThrowsAsync<BasicBillingException>(async () => await _billService.PayBill(clientBillID));
    }

    [Fact]
    public async void PayBill_ReturnsClientBill()
    {
        //Arrange
        var clientBillID = 1;
        ClientBill clientBill = new ClientBill { Id = clientBillID, BillId = 1, ClientId = 1, Status = BillStatus.Paid };

        _mockRepository.Setup(x => x.UpdateBillStatusToPaid(clientBillID)).ReturnsAsync(clientBill);

        //Act
        var result = await _billService.PayBill(clientBillID);

        //Assert
        Assert.Equal(result, clientBill);

    }
}
