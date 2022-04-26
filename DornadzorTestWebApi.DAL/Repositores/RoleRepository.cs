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
    public class RoleRepository : IRepository<Role>
    {
        private readonly DornadzorContext _context;

        public RoleRepository(DornadzorContext context)
        {
            _context = context;
        }

        public async Task<Role> GetById(int id) =>
            await _context.Roles
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> Add(Role role)
        {
            await _context.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.Id;
        }

        public async Task Update(Role entity, Role model)
        {
            entity.Name = model.Name;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Role entity)
        {
            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

    }
}
