using System.Collections.Generic;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public interface IOrderRepo
    {
        public List<Order> GetAllOrders();

        public Order GetOrderById(int orderId);

        public void CreateOrder(Order order);

        public void UpdateOrder(Order order);

        public void DeleteOrder(int orderId);
        
        bool SaveChanges();
    }
}