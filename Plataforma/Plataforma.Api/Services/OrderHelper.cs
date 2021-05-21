using Plataforma.Api.Interfaces;
using Plataforma.Domain.Core;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma.Api.Services
{
    public class OrderHelper : IOrderHelper
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMovementService _movementService;
        public OrderHelper(IProductRepository productRepository, IUserRepository userRepository, IMovementService movementService)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _movementService = movementService;
        }


        public async Task<Notification> ValidateData(CreateOrderViewModel request)
        {
            Notification notification = new Notification();
            try
            {
                if (await _userRepository.GetUserById(request.IdUser) == null)
                    notification.TransactionMessages.Add("Usuário não encontrado");

                var product = await _productRepository.GetById(request.IdProduct);

                if (product == null)
                    notification.TransactionMessages.Add("Produto não encontrado");

                var products = await _productRepository.GetAllAvailable();

                if (!products.Where(c=>c.Id == request.IdProduct).Any())
                    notification.TransactionMessages.Add("Produto não indisponivel");

                var balance = await  _movementService.Balance(request.IdUser);
                if ((product.Points * request.Quantity) > balance.Total)
                    notification.TransactionMessages.Add("Saldo insuficiente para fazer esse resgate.");

                return await Task.FromResult(notification);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
