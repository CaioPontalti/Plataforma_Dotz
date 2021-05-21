using Plataforma.Domain.Entities;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.Response.Product;
using Plataforma.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Infra.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Create(CreateProductViewModel model)
        {
            try
            {
                var entity = new Product()
                {
                    Name = model.Name,
                    Points = model.Value,
                    Quantity = model.Quantity
                };

                var product = await _productRepository.Create(entity);

                ProductResponse response = new ProductResponse()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Value = product.Points,
                    Quantity = product.Quantity
                };

                return await Task.FromResult(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<ProductResponse>> GetAllAvailable()
        {
            var products = await _productRepository.GetAllAvailable();
            List<ProductResponse> productResponse = null;
            if (products != null)
            {
                productResponse = new List<ProductResponse>();
                foreach (var item in products)
                {
                    var user = new ProductResponse()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Value = item.Points,
                        Quantity = item.Quantity
                    };

                    productResponse.Add(user);
                }
            }

            return await Task.FromResult(productResponse);
        }
    }
}
