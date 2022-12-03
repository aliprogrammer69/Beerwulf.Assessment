using BeerWulf.Common.Models;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Models.Queries;
using BeerWulf.Domain.Services;
using BeerWulf.UI.Api.DTOs;
using BeerWulf.UI.Api.Presentores;

using Microsoft.AspNetCore.Mvc;

namespace BeerWulf.UI.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase {
        private readonly IProductReviewPresentore _productReviewPresentore;
        private readonly IProductPresentore _productPresentore;
        private readonly IReviewService _reviewService;

        public ProductController(IProductReviewPresentore productReviewPresentore,
                                 IProductPresentore productPresentore,
                                 IReviewService reviewService) {
            _productReviewPresentore = productReviewPresentore;
            _productPresentore = productPresentore;
            _reviewService = reviewService;
        }

        /// <summary>
        /// Search product info
        /// </summary>
        /// <param name="query">used for filtering products. let this null if want to see all products</param>
        /// <returns></returns>
        [HttpGet]
        public Task<ArrayResult<ProductDto>> Search([FromQuery] ProductQuery query) =>
            _productPresentore.SearchAsync(query);

        [HttpPost]
        [Route("review")]
        public Task<Result> AddReview(ReviewDto review) =>
            _productReviewPresentore.AddAsync(review);

        [HttpGet]
        [Route("{productId}/reviews")]
        public Task<ArrayResult<ReviewDto>> GetReviews(uint productId) =>
            _productReviewPresentore.GetAllAsync(productId);

        [HttpGet]
        [Route("{productId}/reviews/summery")]
        public async Task<Result<ReviewSummery>> GetSummery(uint productId) {
            var result = await _reviewService.GetSummeryAsync(productId);
            if (!result.Success)
                return new Result<ReviewSummery>(result.Code, result.Message);
            return new Result<ReviewSummery>(Common.ResultCode.Ok) {
                Data = new ReviewSummery(result.Data.AvarageScore, result.Data.RecommandationPercentage)
            };
        }
    }
}
