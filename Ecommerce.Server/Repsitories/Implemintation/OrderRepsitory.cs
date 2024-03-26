//using Ecommerce.Server.Models.Domain;
//using Ecommerce.Server.Repositories.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Ecommerce.Server.Repositories.Implementation
//{
//    public class OrderRepository : IOrderRepository
//    {
//        private List<Order> orders = new List<Order>();

//        public async Task<Order> GetOrderById(int orderId)
//        {
//            return await Task.FromResult(orders.Find(o => o.OrderId == orderId));
//        }

//        public Task<List<Order>> GetAll()
//        {
//            return Task.FromResult(orders);
//        }


//        public async Task<bool> AddUpdate(Order order)
//        {
//            if (order.OrderId == 0)
//            {
//                // Add new order
//                order.OrderId = orders.Count + 1;
//                orders.Add(order);
//            }
//            else
//            {
//                // Update existing order
//                Order existingOrder = await GetOrderById(order.OrderId);
//                if (existingOrder != null)
//                {
//                    existingOrder.CustomerName = order.CustomerName;
//                    existingOrder.OrderDate = order.OrderDate;
//                    // Update other properties as needed
//                }
//                else
//                {
//                    return false; // Order not found
//                }
//            }

//            return true;
//        }

//        public async Task<bool> Delete(int orderId)
//        {
//            Order existingOrder = await GetOrderById(orderId);
//            if (existingOrder != null)
//            {
//                orders.Remove(existingOrder);
//                return true;
//            }

//            return false; // Order not found
//        }

  
//    }
//}
