using DornadzorTestWebApi.DAL.Entity;
using DornadzorTestWebApi.DAL.Repositores.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.DAL.Repositores
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly DornadzorContext _context;

        public OrderRepository(DornadzorContext context)
        {
            _context = context;
        }

        public async Task<Order> GetById(int id) =>
            await _context.Orders
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> Add(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task Update(Order entity, Order model)
        {
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.User = model.User;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

    }
}
