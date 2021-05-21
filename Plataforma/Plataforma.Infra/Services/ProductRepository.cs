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
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext contex)
        {
            _context = contex;
        }

        public async Task<Product> Create(Product model)
        {
            try
            {
                var user = await _context.Products.AddAsync(model);
                await _context.SaveChangesAsync();

                return await Task.FromResult(user.Entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAvailable()
        {
            try
            {
                var products = _context.Products.Where(d=>d.Quantity > 0).ToList();

                return await Task.FromResult(products);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Product> GetById(string id)
        {
            try
            {
                var product = _context.Products.Where(d => d.Id == id && d.Quantity > 0).FirstOrDefault();

                return await Task.FromResult(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
