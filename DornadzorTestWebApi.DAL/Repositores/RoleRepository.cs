using DornadzorTestWebApi.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.DAL.Repositores
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DornadzorContext _context;

        public RoleRepository(DornadzorContext context)
        {
            _context = context;
        }

        public Role GetRoleById(int id) =>
            _context.Roles
            .FirstOrDefault(x => x.Id == id);

        public int AddRole(Role role)
        {
            _context.Add(role);
            _context.SaveChanges();
            return role.Id;
        }

        public void UpdateRole(Role entity, Role role)
        {
            entity.Name = role.Name;
            _context.SaveChanges();
        }

        public void DeleteRole(Role entity)
        {
            _context.Roles.Remove(entity);
            _context.SaveChanges();
        }
    }
}
