using Plataforma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Create(Product model);
        Task<IEnumerable<Product>> GetAllAvailable();
        Task<Product> GetById(string id);
    }
}
