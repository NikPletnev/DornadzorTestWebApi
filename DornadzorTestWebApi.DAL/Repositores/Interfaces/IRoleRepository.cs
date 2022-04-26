using DornadzorTestWebApi.DAL.Entity;

namespace DornadzorTestWebApi.DAL.Repositores
{
    public interface IRoleRepository
    {
        int AddRole(Role role);
        void DeleteRole(Role entity);
        Role GetRoleById(int id);
        void UpdateRole(Role entity, Role role);
    }
}