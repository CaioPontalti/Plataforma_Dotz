using Plataforma.Domain.Entities;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.ViewModels.User;
using Plataforma.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Infra.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext contex)
        {
            _context = contex;
        }

        public async Task<User> Create(User model)
        {
            try
            {
                var user =  await _context.Users.AddAsync(model);
                await _context.SaveChangesAsync();

                return await Task.FromResult(user.Entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> GetUser(User model)
        {
            try
            {
                var user = _context.Users.Where(u => u.Email == model.Email && 
                                                u.Password == model.Password).FirstOrDefault();
                return await Task.FromResult(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            try
            {
                var users = _context.Users.ToList();

                return await Task.FromResult(users);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> GetUserById(string id)
        {
            try
            {
                var user = _context.Users.Where(u=>u.Id == id).FirstOrDefault();

                return await Task.FromResult(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AddressUser> CreateAddress(AddressUser model)
        {
            try
            {
                var address = await _context.AddressUsers.AddAsync(model);
                await _context.SaveChangesAsync();

                return await Task.FromResult(address.Entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<AddressUser>> GetAddressByIdUser(string id)
        {
            try
            {
                var address = _context.AddressUsers.Where(u => u.UserId == id);

                return await Task.FromResult(address);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
