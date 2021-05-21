using Plataforma.Domain.Core;
using Plataforma.Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma.Api.Interfaces
{
    public interface IOrderHelper
    {
        Task<Notification> ValidateData(CreateOrderViewModel request);
    }
}
