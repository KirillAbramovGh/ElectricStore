using System.Collections.Generic;
using System.Linq;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public class SqlOrderRepo : IOrderRepo
    {
        private ElectricStoreContext _context;
        
        public SqlOrderRepo(ElectricStoreContext context)
        {
            _context = context;
        }
        
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }

        public void DeleteOrder(int orderId)
        {
            Order order = new Order() { Id = orderId };
            _context.Orders.Attach(order);
            _context.Orders.Remove(order);
        }
        
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}