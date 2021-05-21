using Plataforma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> Create(Order model);
    }
}
