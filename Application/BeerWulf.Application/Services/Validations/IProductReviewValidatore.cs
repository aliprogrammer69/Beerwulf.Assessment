using BeerWulf.Common.Models;
using BeerWulf.Domain.Models;

namespace BeerWulf.Application.Services.Validations {
    public interface IProductReviewValidatore {
        Task<Result> AddAsync(ProductReview review);
    }
}
