using BeerWulf.Common.Models;
using BeerWulf.UI.Api.DTOs;

namespace BeerWulf.UI.Api.Presentores {
    public interface IProductReviewPresentore {
        Task<ArrayResult<ReviewDto>> GetAllAsync(uint productId);
    }
}
