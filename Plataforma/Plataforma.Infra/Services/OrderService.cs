using Plataforma.Domain.Entities;
using Plataforma.Domain.Enums;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.Response.Order;
using Plataforma.Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Infra.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMovementRepository _movementRepository;
        public OrderService(IOrderRepository orderRepository, IMovementRepository movementRepository)
        {
            _orderRepository = orderRepository;
            _movementRepository = movementRepository;
        }

        public async Task<OrderResponse> CreateOrder(CreateOrderViewModel model)
        {
            try
            {
                var entity = new Order()
                {
                    IdUser = model.IdUser,
                    IdProduct = model.IdProduct,
                    EStatusOrder = Domain.Enums.EStatusOrder.OrderRequest,
                    Quantity = model.Quantity,
                    Points = model.Points
                };

                var productCreate = await _orderRepository.Create(entity);

                OrderResponse response = new OrderResponse()
                {
                    Id = productCreate.Id,
                    IdUser = productCreate.IdUser,
                    IdProduct = productCreate.IdProduct,
                    Quantity = productCreate.Quantity,
                    Points = productCreate.Points,
                    EStatusOrder = Enum.GetName(typeof(EStatusOrder), productCreate.EStatusOrder)
                };

                return await Task.FromResult(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
