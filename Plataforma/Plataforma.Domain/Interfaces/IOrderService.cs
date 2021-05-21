using Plataforma.Domain.Response.Order;
using Plataforma.Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrder(CreateOrderViewModel model);
    }
}
