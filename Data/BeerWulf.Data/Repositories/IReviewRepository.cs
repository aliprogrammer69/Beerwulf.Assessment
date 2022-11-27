using BeerWulf.Domain.Models;

namespace BeerWulf.Data.Repositories {
    public interface IReviewRepository {
        Task AddAsync(ProductReview review);
        Task<IEnumerable<ProductReview>> GetAllAsync(uint productId);
        Task<(double AverageScore, double RecommandationPercentage)> GetSummeryAsync(uint productId);
    }
}
