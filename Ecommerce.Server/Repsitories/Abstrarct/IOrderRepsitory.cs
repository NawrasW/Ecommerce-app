using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Server.Models.Domain;

namespace Ecommerce.Server.Repositories.Abstract
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int orderId);

        Task<List<Order>> GetAll();

        Task<bool> AddUpdate(Order order);

        Task<bool> Delete(int orderId);

        // Additional methods can be added based on your requirements
    }
}
