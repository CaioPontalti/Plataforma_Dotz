using Plataforma.Domain.Response.Balance;
using Plataforma.Domain.ViewModels.Balance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Domain.Interfaces
{
    public interface IMovementService
    {
        Task<BalanceResponse> CreateMovement(CreateMovementViewModel model);
        Task<IEnumerable<ExtractResponse>> Extract(string id);
        Task<BalanceUserResponse> Balance(string id);
    }
}
