using DornadzorTestWebApi.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DornadzorTestWebApi.DAL.Repositores
{
    public class UserRepository : IUserRepository
    {
        private readonly DornadzorContext _context;

        public UserRepository(DornadzorContext context)
        {
            _context = context;
        }

        public User GetUserById(int id) =>
            _context.Users
            .Include(w => w.Orders)
            .FirstOrDefault(x => x.Id == id);

        public int AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(User entity, User user)
        {
            entity.Name = user.Name;
            entity.Age = user.Age;
            entity.Role = user.Role;
            entity.Orders = user.Orders;
            _context.SaveChanges();
        }

        public void DeleteUser(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }
    }
}
