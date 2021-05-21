using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Domain.Core;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("register")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductViewModel model)
        {
            try
            {
                var notificatons = model.Validate();
                if (notificatons.TransactionMessages.Count > 0)
                    return BadRequest(new Response(false, "Dados do Produto inválidos",
                        new { Messages = notificatons.TransactionMessages }));

                var movement = await _productService.Create(model);

                return Ok(new Response(true, "Produto cadastrado com sucesso.",
                    new { Movement = movement }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("getallproductsavailable")]
        [Authorize]
        public async Task<IActionResult> GetAllAvailable()
        {
            try
            {
                var products = await _productService.GetAllAvailable();

                if (products == null)
                    return NotFound("Nenhum produto cadastrado .");

                return Ok(new Response(true, "Lista de Produtos disponíveis.",
                    new { Products = products }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
