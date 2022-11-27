using BeerWulf.Application.Services.Validations;
using BeerWulf.Application.Services.Validations.Impls;
using BeerWulf.Common;
using BeerWulf.Common.Models;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;

using Moq;

namespace BeerWulf.Test.UnitTest.ValidatoreTests {
    public class ProductReviewValidatoreTests {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly IProductReviewValidatore _productReviewValidatore;
        public ProductReviewValidatoreTests() {
            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(p => p.ExistsAsync(1)).Returns(Task.FromResult(true));
            _productRepository.Setup(p => p.ExistsAsync(10)).Returns(Task.FromResult(false));

            _productReviewValidatore = new ProductReviewValidatore(_productRepository.Object);

        }

        [Theory]
        [MemberData(nameof(ProductReviews))]
        public async void Shuold_Return_BadRequest(ProductReview review) {
            Result result = await _productReviewValidatore.AddAsync(review);
            Assert.False(result.Success);
            Assert.Equal(ResultCode.BadRequest, result.Code);
        }

        [Fact]
        public async void Score_Should_Be_1() {
            ProductReview review = new ProductReview() {
                Product = new Product() {
                    Id = 1
                },
                Title = "Test",
                Comment = "Test",
                Score = 0,
                ProductRecommended = false,
            };

            Result result = await _productReviewValidatore.AddAsync(review);
            Assert.True(result.Success);
            Assert.Equal(1, review.Score);
        }

        [Fact]
        public async void Score_Should_Be_5() {
            ProductReview review = new ProductReview() {
                Product = new Product() {
                    Id = 1
                },
                Title = "Test",
                Comment = "Test",
                Score = 100,
                ProductRecommended = true,
            };

            Result result = await _productReviewValidatore.AddAsync(review);
            Assert.True(result.Success);
            Assert.Equal(5, review.Score);
        }

        public static IEnumerable<object[]> ProductReviews() {
            Product product = new Product() { Id = 1 };
            return new List<object[]>(6) {
                new object[1]{new ProductReview() {
                    Product = product,
                    Title= "Test",
                    Score = 5,
                    ProductRecommended = true
                }
                },
                new object[1]{new ProductReview() {
                    Product = product,
                    Comment= "Test",
                    Score = 2,
                    ProductRecommended = false
                }
                },
                new object[1]{new ProductReview() {
                    Title= "Test",
                    Comment = "Test",
                    Score = 5,
                    ProductRecommended = true
                }
                },
                new object[1]{new ProductReview() {
                    Product = new Product(),
                    Title= "Test",
                    Comment = "Test",
                    Score = 5,
                    ProductRecommended = true
                }
                },
                new object[1]{new ProductReview() {
                    Product = new Product(),
                    Title= "  ",
                    Comment = "  ",
                    Score = 5,
                    ProductRecommended = true
                }
                },
                new object[1]{new ProductReview() {
                    Product = new Product(){Id = 10},
                    Title= "Test",
                    Comment = "Test",
                    Score = 5,
                    ProductRecommended = true
                }
                }
            };
        }

    }
}
