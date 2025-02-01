using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using OrderService.Protos;

namespace OrderService.Services
{
    public class OrderService : OrderServiceBase
    {
        private readonly List<Order> _orders = new List<Order>();

        public override Task<OrderResponse> CreateOrder(OrderRequest request, ServerCallContext context)
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                Quantity = request.Quantity,
                Status = "Pending"
            };

            _orders.Add(order);

            return Task.FromResult(new OrderResponse { OrderId = order.Id });
        }

        public override Task<OrderListResponse> GetOrders(GetOrdersRequest request, ServerCallContext context)
        {
            var response = new OrderListResponse();
            response.Orders.AddRange(_orders);

            return Task.FromResult(response);
        }

        public override Task<OrderResponse> UpdateOrder(UpdateOrderRequest request, ServerCallContext context)
        {
            var order = _orders.FirstOrDefault(o => o.Id == request.OrderId);
            if (order != null)
            {
                order.Status = request.Status;
            }

            return Task.FromResult(new OrderResponse { OrderId = order?.Id });
        }

        public override Task<OrderResponse> DeleteOrder(DeleteOrderRequest request, ServerCallContext context)
        {
            var order = _orders.FirstOrDefault(o => o.Id == request.OrderId);
            if (order != null)
            {
                _orders.Remove(order);
            }

            return Task.FromResult(new OrderResponse { OrderId = order?.Id });
        }
    }
}