using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Models.Queries;

using Microsoft.EntityFrameworkCore;

namespace BeerWulf.Data.Impl.EF.Repositories {
    public class ProductRepository : IProductRepository {
        private readonly BeerWulfProductReviewDbContext _dbContext;

        public ProductRepository(BeerWulfProductReviewDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product) {
            await _dbContext.Products.AddAsync(product);
        }

        public Task<bool> ExistsAsync(uint productId) =>
            _dbContext.Products.AsNoTracking()
                               .AnyAsync(p => p.Id == productId);


        public async Task<IEnumerable<Product>> GetAllAsync(ProductQuery query = null) =>
            await _dbContext.Products.Where(p => query == null ||
                                           ((!query.Id.HasValue || p.Id == query.Id) &&
                                           (string.IsNullOrWhiteSpace(query.Name) || p.Name.Contains(query.Name)) &&
                                           (string.IsNullOrWhiteSpace(query.Description) || p.Description.Contains(query.Description))))
                                     .ToListAsync();
    }
}
