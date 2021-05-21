using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Plataforma.Api.Services;
using Plataforma.Api.ViewModels.User;
using Plataforma.Domain.Core;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService,  IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel model)
        {
            try
            {
                var notificatons = model.Validate();
                if (notificatons.TransactionMessages.Count > 0)
                    return BadRequest(new Response(false, "Dados inválidos", 
                        new { Messages = notificatons.TransactionMessages }));

                var user =  await _userService.CreateUser(model);

                return Ok(new Response(true, "Usuário Cadastrado com sucesso.",
                    new { User = user }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel userLogin)
        {
            try
            {
                var user = await _userService.GetUserLogin(userLogin);

                if (user == null)
                    return NotFound("Usuário ou Senha inválidos.");

                var instaceToken = new TokenService(_configuration);
                var token = await instaceToken.GenerateToken(user);

                return Ok(new Response(true, "Login Efetuado.",
                    new { token = token }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpGet]
        [Route("getuser/{Id}")]
        [Authorize]
        public async Task<IActionResult> GetById(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                    return BadRequest("Id do usuário não informado.");

                var user = await _userService.GetUserById(Id);

                if (user == null)
                    return NotFound("Nenhum usuário encontrado.");

                return Ok(new Response(true, "Dados do usuário.",
                    new { User = user }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("getallusers")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = await _userService.GetAllUser();

                if (user == null)
                    return NotFound("Nenhum usuário cadastrado .");

                return Ok(new Response(true, "Lista de Usuários.",
                    new { Users = user }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost]
        [Route("createaddress")]
        [Authorize]
        public async Task<IActionResult> CreateAddress([FromBody] AddressUserViewModel model)
        {
            try
            {
                var notificatons = model.Validate();
                if (notificatons.TransactionMessages.Count > 0)
                    return BadRequest(new Response(false, "Dados de endereço inválidos",
                        new { Messages = notificatons.TransactionMessages }));

                if (await _userService.GetUserById(model.UserId) == null)
                    return NotFound(new Response(false, "Usuário não encontrado",
                        new { UserId = model.UserId }));

                var response = await _userService.CreateAddress(model);
                
                return Ok(new Response(true, "Endereço cadastrado com sucesso.",
                    new { Address = response }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("addressbyuserid/{Id}")]
        [Authorize]
        public async Task<IActionResult> GetAddressByIdUser(string Id)
        {
            try
            {
                var address = await _userService.GetAddressByIdUser(Id);

                if (address == null)
                    return NotFound("Nenhum endereço encontrado.");

                return Ok(new Response(true, "Lista de endereços do usuário.",
                    new { Address = address }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
