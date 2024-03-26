using Ecommerce.Server.Models.Domain;
using Ecommerce.Server.Repositories.Abstract;

namespace Ecommerce.Server.Repositories.Implementation
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private List<OrderItem> orderItems = new List<OrderItem>();

        public Task<OrderItem> GetOrderItemById(int orderItemId)
        {
            return Task.FromResult(orderItems.Find(oi => oi.OrderItemId == orderItemId));
        }

        public Task<List<OrderItem>> GetOrderItemsByOrderId(int orderId)
        {
            return Task.FromResult(orderItems.FindAll(oi => oi.OrderId == orderId));
        }

        public Task AddOrderItem(OrderItem orderItem)
        {
            orderItems.Add(orderItem);
            return Task.CompletedTask;
        }

        public Task UpdateOrderItem(OrderItem orderItem)
        {
            OrderItem existingOrderItem = orderItems.Find(oi => oi.OrderItemId == orderItem.OrderItemId);
            if (existingOrderItem != null)
            {
                orderItems.Remove(existingOrderItem);
                orderItems.Add(orderItem);
            }

            return Task.CompletedTask;
        }

        public Task DeleteOrderItem(int orderItemId)
        {
            OrderItem existingOrderItem = orderItems.Find(oi => oi.OrderItemId == orderItemId);
            if (existingOrderItem != null)
            {
                orderItems.Remove(existingOrderItem);
            }

            return Task.CompletedTask;
        }
    }
}
