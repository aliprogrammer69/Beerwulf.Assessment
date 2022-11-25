using BeerWulf.Common.Models;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Models.Queries;
using BeerWulf.Domain.Services;
using BeerWulf.UI.Api.Models;

using Microsoft.AspNetCore.Mvc;

namespace BeerWulf.UI.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public ProductController(IProductService productService,
                                 IReviewService reviewService) {
            _productService = productService;
            _reviewService = reviewService;
        }

        [HttpGet]
        public Task<ArrayResult<Product>> Get([FromQuery] ProductQuery query) =>
            _productService.GetAllAsync(query);

        [HttpPost]
        [Route("review")]
        public Task<Result> AddReview(ProductReview review) =>
            _reviewService.AddAsync(review);

        [HttpGet]
        [Route("{productId}/reviews")]
        public Task<ArrayResult<ProductReview>> GetReviews(uint productId) =>
            _reviewService.GetAllAsync(productId);

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
