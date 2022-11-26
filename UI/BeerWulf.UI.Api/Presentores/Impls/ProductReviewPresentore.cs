using BeerWulf.Common.Models;
using BeerWulf.Common.Utils;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Services;
using BeerWulf.UI.Api.DTOs;

namespace BeerWulf.UI.Api.Presentores.Impls {
    public class ProductReviewPresentore : IProductReviewPresentore {
        private readonly IReviewService _reviewService;
        private readonly IObjectMapper _mapper;

        public ProductReviewPresentore(IReviewService reviewService,
                                       IObjectMapper mapper) {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        public async Task<ArrayResult<ReviewDto>> GetAllAsync(uint productId) {
            ArrayResult<ProductReview> result = await _reviewService.GetAllAsync(productId);
            if (!result.Success)
                return new ArrayResult<ReviewDto>(result.Code, result.Message);
            return new ArrayResult<ReviewDto>(Common.ResultCode.Ok) {
                Data = _mapper.Map<IEnumerable<ReviewDto>>(result.Data)
            };
        }
    }
}
