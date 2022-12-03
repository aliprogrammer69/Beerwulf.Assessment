using BeerWulf.Application.Services;
using BeerWulf.Application.Services.Validations;
using BeerWulf.Common;
using BeerWulf.Common.Models;
using BeerWulf.Data;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Services;

using Moq;

namespace BeerWulf.Test.UnitTest.ServiceTests {
    public class ReviewServiceTests {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IProductReviewValidatore> _productReviewValidatore;
        private readonly Mock<IReviewRepository> _reviewRepository;
        private readonly IReviewService _reviewService;
        public ReviewServiceTests() {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.SaveChangesAsync(default)).Returns(Task.CompletedTask);

            _productReviewValidatore = new Mock<IProductReviewValidatore>();
            _reviewRepository = new Mock<IReviewRepository>();

            _reviewService = new ReviewService(_reviewRepository.Object,
                                               _productReviewValidatore.Object,
                                               _unitOfWork.Object);
        }

        [Fact]
        public async void Should_Add_Review() {
            ProductReview review = new ProductReview() {
                Product = new Product() {
                    Id = 1
                },
                Comment = "Test",
                Title = "Test",
                Score = 5
            };
            _productReviewValidatore.Setup(p => p.AddAsync(review)).Returns(Task.FromResult(new Result(ResultCode.Ok)));

            Result result = await _reviewService.AddAsync(review);
            Assert.True(result.Success);
        }

        [Fact]
        public async void Should_Return_BadRequest() {
            ProductReview review = new ProductReview() {
                Product = new Product() {
                    Id = 1
                },
                Title = "Test",
                Score = 5
            };
            _productReviewValidatore.Setup(p => p.AddAsync(review)).Returns(Task.FromResult(new Result(ResultCode.BadRequest)));

            Result result = await _reviewService.AddAsync(review);
            Assert.False(result.Success);
            Assert.Equal(ResultCode.BadRequest, result.Code);
        }

        [Fact]
        public async void Should_Return_Products() {
            _reviewRepository.Setup(r => r.GetAllAsync(1)).Returns(Task.FromResult<IEnumerable<ProductReview>>(new List<ProductReview>(1) { new ProductReview() }));
            ArrayResult<ProductReview> result = await _reviewService.GetAllAsync(1);
            Assert.True(result.Success);
            Assert.True(result.Data.Any());
        }
    }
}
