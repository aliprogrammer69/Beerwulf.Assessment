using BeerWulf.Common.Models;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Models.Queries;

namespace BeerWulf.Domain.Services {
    public interface IProductService {
        Task<ArrayResult<Product>> GetAllAsync(ProductQuery query = null);
    }
}
