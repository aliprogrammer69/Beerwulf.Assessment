using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace BeerWulf.Data.Impl.EF.Repositories {
    public class ReviewRepository : IReviewRepository {
        private readonly BeerWulfProductReviewDbContext _dbContext;

        public ReviewRepository(BeerWulfProductReviewDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProductReview review) {
            await _dbContext.AddAsync(review);
        }

        public async Task<IEnumerable<ProductReview>> GetAllAsync(uint productId) =>
            await _dbContext.Products.Where(p => p.Id == productId)
                                     .SelectMany(p => p.Reviews).ToListAsync();

        public async Task<(double AvarageScore, double RecommandationPercentage)> GetSummeryAsync(uint productId) {
            var result = await _dbContext.Products.Where(p => p.Id == productId)
                                                  .Select(p => new {
                                                      ScoreAverage = p.Reviews.Average(p => p.Score),
                                                      RecommandetionPercentage = p.Reviews.Average(p => p.ProductRecommended ? 1 : 0) * 100
                                                  }).FirstOrDefaultAsync();
            return (result.ScoreAverage, result.RecommandetionPercentage);
        }
    }
}
