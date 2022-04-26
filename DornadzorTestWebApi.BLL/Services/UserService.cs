using AutoMapper;
using DornadzorTestWebApi.BLL.Exeptions;
using DornadzorTestWebApi.BLL.Models;
using DornadzorTestWebApi.BLL.Services.Interfaces;
using DornadzorTestWebApi.DAL.Entity;
using DornadzorTestWebApi.DAL.Repositores;
using DornadzorTestWebApi.DAL.Repositores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.BLL.Services
{
    public class UserService : IService<UserModel>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _roleRepository;

        public UserService(IRepository<User> userRepository, IMapper mapper, IRepository<Role> roleRepository)
        {
            _repository = userRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<UserModel> GetById(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with id {id} not found");
            }
            return _mapper.Map<UserModel>(user);
        }

        public async Task<int> Add(UserModel userModel)
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
            var role = await _roleRepository.GetById(userModel.Role.Id);
            if (role == null)
            {
                throw new EntityNotFoundException($"Role {userModel.Role} not found");
            }
            return await _repository.Add(userEntity);
        }

        public async Task Update(UserModel userModel)
        {
            var userEntity = await _repository.GetById(userModel.Id);
            if (userEntity == null)
            {
                throw new EntityNotFoundException("User not found");
            }
            if (userModel.Role == null)
            {
                throw new ServiceNotEnoughDataExeption("There is not enough data to update new user");
            }
            var role = await _roleRepository.GetById(userModel.Role.Id);
            if (role == null)
            {
                throw new EntityNotFoundException($"Role {userModel.Role} not found");
            }
            await _repository.Update(userEntity, _mapper.Map<User>(userModel));
        }

        public async Task Delete(int id)
        {
            var userEntity = await _repository.GetById(id);
            if (userEntity == null)
            {
                throw new EntityNotFoundException($"User with id {id} not found");
            }
            await _repository.Delete(userEntity);
        }

        public async Task Delete(UserModel entity)
        {
            var userEntity = await _repository.GetById(entity.Id);
            if (userEntity == null)
            {
                throw new EntityNotFoundException($"User with id {entity.Id} not found");
            }
            await _repository.Delete(userEntity);
        }

        public async Task<List<UserModel>> GetAll()
        {
            return _mapper.Map<List<UserModel>>(await _repository.GetAll());
        }
    }
}

