using Plataforma.Domain.Response.Product;
using Plataforma.Domain.ViewModels.Product;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plataforma.Domain.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> Create(CreateProductViewModel model);
        Task<IEnumerable<ProductResponse>> GetAllAvailable();
    }
}
