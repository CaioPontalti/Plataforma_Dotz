using Plataforma.Domain.Entities;
using Plataforma.Domain.Interfaces;
using Plataforma.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Infra.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext contex)
        {
            _context = contex;
        }

        public async Task<Order> Create(Order model)
        {
            try
            {
                var user = await _context.Orders.AddAsync(model);
                await _context.SaveChangesAsync();

                return await Task.FromResult(user.Entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
