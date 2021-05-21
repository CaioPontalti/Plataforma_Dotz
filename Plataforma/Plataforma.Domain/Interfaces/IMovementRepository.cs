using Plataforma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Domain.Interfaces
{
    public interface IMovementRepository
    {
        Task<Balance> Create(Balance model);
        Task<IEnumerable<Balance>> Extract(string id);
    }
}
