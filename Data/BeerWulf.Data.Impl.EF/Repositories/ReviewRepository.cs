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
            _dbContext.Entry(review.Product).State = EntityState.Unchanged;
            await _dbContext.ProductReviews.AddAsync(review);
        }

        public async Task<IEnumerable<ProductReview>> GetAllAsync(uint productId) =>
            await _dbContext.ProductReviews.Where(p => p.Product.Id == productId)
                                           .ToListAsync();

        public async Task<(double AverageScore, double RecommandationPercentage)> GetSummeryAsync(uint productId) {
            var result = await _dbContext.Products.AsNoTracking()
                                                  .Include(p => p.Reviews)
                                                  .Where(p => p.Id == productId)
                                                  .Select(p => new {
                                                      ScoreAverage = p.Reviews.Average(p => p.Score),
                                                      RecommandetionPercentage = p.Reviews.Average(p => p.ProductRecommended ?? false ? 1 : 0) * 100
                                                  }).FirstOrDefaultAsync();
            return (result.ScoreAverage, result.RecommandetionPercentage);
        }
    }
}
