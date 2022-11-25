using BeerWulf.Common.Models;
using BeerWulf.Domain.Models;

namespace BeerWulf.Domain.Services {
    public interface IReviewService {
        Task<Result> AddAsync(ProductReview review);
        Task<ArrayResult<ProductReview>> GetAllAsync(uint productId);
        Task<Result<(double AvarageScore, double RecommandationPercentage)>> GetSummeryAsync(uint productId);
    }
}
