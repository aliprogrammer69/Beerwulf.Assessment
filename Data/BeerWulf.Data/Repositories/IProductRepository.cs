using BeerWulf.Domain.Models;
using BeerWulf.Domain.Models.Queries;

namespace BeerWulf.Data.Repositories {
    public interface IProductRepository {
        Task AddAsync(Product product);
        Task<bool> ExistsAsync(uint productId);

        Task<IEnumerable<Product>> GetAllAsync(ProductQuery query = null);
    }
}
