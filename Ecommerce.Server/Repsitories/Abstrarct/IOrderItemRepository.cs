using Ecommerce.Server.Models.Domain;

namespace Ecommerce.Server.Repositories.Abstract
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetOrderItemById(int orderItemId);
        Task<List<OrderItem>> GetOrderItemsByOrderId(int orderId);
        Task AddOrderItem(OrderItem orderItem);
        Task UpdateOrderItem(OrderItem orderItem);
        Task DeleteOrderItem(int orderItemId);
    }
}