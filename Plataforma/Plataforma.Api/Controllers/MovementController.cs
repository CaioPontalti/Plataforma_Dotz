using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Domain.Core;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.ViewModels.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;
        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpPost]
        [Route("register")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateMovementViewModel model)
        {
            try
            {
                var notificatons = model.Validate();
                if (notificatons.TransactionMessages.Count > 0)
                    return BadRequest(new Response(false, "Dados da movimentação inválidos",
                        new { Messages = notificatons.TransactionMessages }));

                var movement = await _movementService.CreateMovement(model);

                return Ok(new Response(true, "Movimentação com sucesso.",
                    new { Movement = movement }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("extract/{id}")]
        [Authorize]
        public async Task<IActionResult> Extract(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("Id do usuário não informado.");

                var movement = await _movementService.Extract(id);

                return Ok(new Response(true, "Extrato do Usuário.",
                    new { Movement = movement }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("balance/{id}")]
        [Authorize]
        public async Task<IActionResult> Balance(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("Id do usuário não informado.");

                var balance = await _movementService.Balance(id);

                return Ok(new Response(true, "Saldo do Usuário.",
                    new { Balance = balance }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
