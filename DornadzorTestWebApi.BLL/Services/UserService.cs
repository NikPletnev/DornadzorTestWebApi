using AutoMapper;
using DornadzorTestWebApi.BLL.Exeptions;
using DornadzorTestWebApi.BLL.Models;
using DornadzorTestWebApi.DAL.Entity;
using DornadzorTestWebApi.DAL.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository)
        {
            _repository = userRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public UserModel GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with id {id} not found");
            }
            return _mapper.Map<UserModel>(user);
        }

        public int AddUser(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentNullException("user");
            }
            if (userModel.Role == null)
            {
                throw new ServiceNotEnoughDataExeption("There is not enough data to create new user");
            }
            var userEntity = _mapper.Map<User>(userModel);
            var role = _roleRepository.GetRoleById(userModel.Role.Id);
            if (role == null)
            {
                throw new EntityNotFoundException($"Role {userModel.Role} not found");
            }
            return _repository.AddUser(userEntity);
        }

        public void UpdateUser(UserModel userModel)
        {
            var userEntity = _repository.GetUserById(userModel.Id);
            if (userEntity == null)
            {
                throw new EntityNotFoundException("User not found");
            }
            if (userModel.Role == null)
            {
                throw new ServiceNotEnoughDataExeption("There is not enough data to update new user");
            }
            var role = _roleRepository.GetRoleById(userModel.Role.Id);
            if (role == null)
            {
                throw new EntityNotFoundException($"Role {userModel.Role} not found");
            }
            _repository.UpdateUser(userEntity, _mapper.Map<User>(userModel));
        }

        public void DeleteUserById(int id)
        {
            var userEntity = _repository.GetUserById(id);
            if (userEntity == null)
            {
                throw new EntityNotFoundException($"User with id {id} not found");
            }
            _repository.DeleteUser(userEntity);
        }
    }
}

