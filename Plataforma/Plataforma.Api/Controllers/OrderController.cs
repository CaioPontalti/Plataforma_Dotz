using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Api.Interfaces;
using Plataforma.Domain.Core;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.ViewModels.Balance;
using Plataforma.Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderHelper _orderHelper;
        private readonly IMovementService _movementService;
        public OrderController(IOrderService orderService, IOrderHelper orderHelper, IMovementService movementService)
        {
            _orderService = orderService;
            _orderHelper = orderHelper;
            _movementService = movementService;
        }

        [HttpPost]
        [Route("register")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOrderViewModel model)
        {
            try
            {
                var notificatons = model.Validate();
                if (notificatons.TransactionMessages.Count > 0)
                    return BadRequest(new Response(false, "Dados do pedido inválidos",
                        new { Messages = notificatons.TransactionMessages }));

                notificatons = await _orderHelper.ValidateData(model);
                if (notificatons.TransactionMessages.Count > 0)
                    return BadRequest(new Response(false, "Dados do pedido inválidos",
                        new { Messages = notificatons.TransactionMessages }));

                var order = await _orderService.CreateOrder(model);

                CreateMovementViewModel movement = new CreateMovementViewModel()
                {
                    UserId = model.IdUser,
                    Points = model.Points * model.Quantity,
                    Type = Domain.Enums.EMovementType.Debit
                };

                var resultMovement = await _movementService.CreateMovement(movement);

                return Ok(new Response(true, "Pedido com sucesso.",
                    new { Order = order }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
