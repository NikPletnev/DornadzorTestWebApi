using DornadzorTestWebApi.DAL.Entity;

namespace DornadzorTestWebApi.DAL.Repositores
{
    public interface IUserRepository
    {
        int AddUser(User user);
        void DeleteUserById(User entity);
        User GetUserById(int id);
        void UpdateUser(User entity, User user);
    }
}