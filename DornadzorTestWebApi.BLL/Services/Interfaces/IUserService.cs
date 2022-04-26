using DornadzorTestWebApi.BLL.Models;

namespace DornadzorTestWebApi.BLL.Services
{
    public interface IUserService
    {
        int AddUser(UserModel userModel);
        void DeleteUserById(int id);
        UserModel GetUserById(int id);
        void UpdateUser(UserModel userModel);
    }
}