using Plataforma.Domain.Entities;
using Plataforma.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User model);
        Task<User> GetUserById(string id);
        Task<User> GetUser(User model);
        Task<IEnumerable<User>> GetAllUser();
        Task<AddressUser> CreateAddress(AddressUser model);
        Task<IEnumerable<AddressUser>> GetAddressByIdUser(string id);
    }
}
