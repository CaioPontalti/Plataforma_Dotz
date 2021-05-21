using Plataforma.Api.ViewModels.User;
using Plataforma.Domain.Entities;
using Plataforma.Domain.Response.User;
using Plataforma.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateUser(CreateUserViewModel user);
        Task<User> GetUserLogin(LoginUserViewModel user);
        Task<IEnumerable<UserResponse>> GetAllUser();
        Task<UserResponse> GetUserById(string id);
        Task<AddressUserResponse> CreateAddress(AddressUserViewModel model);
        Task<IEnumerable<AddressUserResponse>> GetAddressByIdUser(string id);
    }
}
