using DornadzorTestWebApi.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.DAL.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DornadzorContext _context;

        public OrderRepository(DornadzorContext context)
        {
            _context = context;
        }

        public Order GetOrderById(int id) =>
            _context.Orders
            .FirstOrDefault(x => x.Id == id);

        public int AddOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
            return order.Id;
        }

        public void UpdateOrder(Order entity, Order order)
        {
            entity.Name = order.Name;
            entity.Description = order.Description;
            entity.Price = order.Price;
            entity.User = order.User;
            _context.SaveChanges();
        }

        public void DeleteOrder(Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }
    }
}
