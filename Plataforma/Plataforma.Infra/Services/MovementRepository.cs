using Plataforma.Domain.Entities;
using Plataforma.Domain.Interfaces;
using Plataforma.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Infra.Services
{
    public class MovementRepository : IMovementRepository
    {

        private readonly DataContext _context;

        public MovementRepository(DataContext contex)
        {
            _context = contex;
        }


        public async Task<Balance> Create(Balance model)
        {
            try
            {
                var user = await _context.Balances.AddAsync(model);
                await _context.SaveChangesAsync();

                return await Task.FromResult(user.Entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Balance>> Extract(string id)
        {
            try
            {
                var extract = _context.Balances.Where(x => x.UserId == id);
                
                return await Task.FromResult(extract);
            }
            catch (Exception e)
            {
                throw e;
            };
        }
    }
}
