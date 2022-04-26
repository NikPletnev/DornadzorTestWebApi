using DornadzorTestWebApi.DAL.Entity;
using DornadzorTestWebApi.DAL.Repositores.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.DAL.Repositores
{
    public class UserRepository : IRepository<User>
    {
        private readonly DornadzorContext _context;

        public UserRepository(DornadzorContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int id) =>
            await _context.Users
            .Include(w => w.Orders)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> Add(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task Update(User entity, User model)
        {
            entity.Name = model.Name;
            entity.Age = model.Age;
            entity.Role = model.Role;
            entity.Orders = model.Orders;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll() =>
            await _context.Users.ToListAsync();


    }
}
