using Plataforma.Api.ViewModels.User;
using Plataforma.Domain.Entities;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.Response.User;
using Plataforma.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AddressUserResponse> CreateAddress(AddressUserViewModel model)
        {
            AddressUserResponse response = null;
            try
            {
                var entity = new AddressUser()
                {
                    UserId = model.UserId,
                    Address = model.Address,
                    Complement = model.Complement,
                    Number = model.Number,
                    ZipCode = model.ZipCode,
                    State = model.State,
                    City = model.City,
                    District = model.District
                };

                var address = await _userRepository.CreateAddress(entity);

                response = new AddressUserResponse()
                {
                    Id = address.Id,
                    UserId = address.UserId,
                    Address = address.Address,
                    Complement = address.Complement,
                    Number = address.Number,
                    ZipCode = address.ZipCode,
                    State = address.State,
                    City = address.City,
                    District = address.District,
                    Activo = address.Activo
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserResponse> CreateUser(CreateUserViewModel user)
        {
            var entity = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

            var userCreate = await _userRepository.Create(entity);

            UserResponse response = new UserResponse()
            {
                Id = userCreate.Id,
                Name = userCreate.Name,
                Email = userCreate.Email,
            };

            return await Task.FromResult(response);
        }

        public async Task<IEnumerable<AddressUserResponse>> GetAddressByIdUser(string id)
        {
            var adrress = await _userRepository.GetAddressByIdUser(id);
            List<AddressUserResponse> lstAddress = null;

            if (adrress != null)
            {
                lstAddress = new List<AddressUserResponse>();
                foreach (var item in adrress)
                {
                    var adrs = new AddressUserResponse()
                    {
                        Id = item.Id,
                        UserId = item.UserId,
                        Address = item.Address,
                        Complement = item.Complement,
                        Number = item.Number,
                        ZipCode = item.ZipCode,
                        State = item.State,
                        City = item.City,
                        District = item.District,
                        Activo = item.Activo
                    };
                    lstAddress.Add(adrs);
                }
            }

            return await Task.FromResult(lstAddress);
        }

        public async Task<IEnumerable<UserResponse>> GetAllUser()
        {
            var users = await _userRepository.GetAllUser();
            List<UserResponse> lstUsers = null;
            if (users != null)
            {
                lstUsers = new List<UserResponse>();
                foreach (var item in users)
                {
                    var user = new UserResponse()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email
                    };

                    lstUsers.Add(user);
                }
            }

            return await Task.FromResult(lstUsers);
        }

        public async Task<UserResponse> GetUserById(string id)
        {
            var userRepo = await _userRepository.GetUserById(id);
            UserResponse user = null;

            if (userRepo != null)
            {
                user = new UserResponse()
                {
                    Id = userRepo.Id,
                    Name = userRepo.Name,
                    Email = userRepo.Email
                };
            }

            return await Task.FromResult(user);
        }

        public async Task<User> GetUserLogin(LoginUserViewModel user)
        {
            var entity = new User()
            {
                Email = user.Email,
                Password = user.Password
            };

            var userLogin = await _userRepository.GetUser(entity);

            return await Task.FromResult(userLogin);
        }
    }
}
