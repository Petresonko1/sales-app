using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using System.Threading.Tasks;
using OrderService.Protos;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService.OrderServiceClient _orderServiceClient;

        public OrderController(OrderService.OrderServiceClient orderServiceClient)
        {
            _orderServiceClient = orderServiceClient;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var response = await _orderServiceClient.CreateOrderAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var request = new GetOrderRequest { Id = id };
            var response = await _orderServiceClient.GetOrderAsync(request);
            return Ok(response);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            var request = new GetOrdersByCustomerRequest { CustomerId = customerId };
            var response = await _orderServiceClient.GetOrdersByCustomerAsync(request);
            return Ok(response);
        }
    }
}