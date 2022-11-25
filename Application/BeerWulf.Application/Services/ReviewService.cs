using BeerWulf.Application.Services.Validations;
using BeerWulf.Common;
using BeerWulf.Common.Models;
using BeerWulf.Data;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Services;

namespace BeerWulf.Application.Services {
    public class ReviewService : IReviewService {
        private readonly IReviewRepository _reviewRepository;
        private readonly IProductReviewValidatore _productReviewValidatore;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository,
                             IProductReviewValidatore productReviewValidatore,
                             IUnitOfWork unitOfWork) {
            _reviewRepository = reviewRepository;
            _productReviewValidatore = productReviewValidatore;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddAsync(ProductReview review) {
            Result validatoreResult = await _productReviewValidatore.AddAsync(review);
            if (!validatoreResult.Success)
                return validatoreResult;
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.SaveChangesAsync();
            return new Result(ResultCode.Ok);
        }

        public async Task<ArrayResult<ProductReview>> GetAllAsync(uint productId) {
            IEnumerable<ProductReview> reviews = await _reviewRepository.GetAllAsync(productId);
            return new ArrayResult<ProductReview>(ResultCode.Ok) {
                Data = reviews
            };
        }

        public async Task<Result<(double AvarageScore, double RecommandationPercentage)>> GetSummeryAsync(uint productId) {
            (double AvarageScore, double RecommandationPercentage) result = await _reviewRepository.GetSummeryAsync(productId);
            return new Result<(double AvarageScore, double RecommandationPercentage)>(ResultCode.Ok) {
                Data = result
            };
        }
    }
}
