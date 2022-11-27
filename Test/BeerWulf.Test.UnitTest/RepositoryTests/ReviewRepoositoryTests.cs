using BeerWulf.Data.Impl.EF.Repositories;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;

namespace BeerWulf.Test.UnitTest.RepositoryTests {
    public class ReviewRepoositoryTests : BaseRepositoryTest {
        private readonly IReviewRepository _reviewRepository;
        public ReviewRepoositoryTests() {
            _reviewRepository = new ReviewRepository(_dbContext);
        }

        [Fact]
        public async void Should_Add_Review() {
            ProductReview review = new ProductReview() {
                Product = new Product {
                    Id = 1
                },
                Title = "Test",
                Comment = "Test",
                Score = 4,
                ProductRecommended = true
            };

            await _reviewRepository.AddAsync(review);
            Assert.True(_dbContext.Entry(review).State == Microsoft.EntityFrameworkCore.EntityState.Added);
        }

        [Fact]
        public async void Product_Should_Be_Unchanged() {
            ProductReview review = new ProductReview() {
                Product = new Product {
                    Id = 1
                },
                Title = "Test",
                Comment = "Test",
                Score = 4,
                ProductRecommended = true
            };

            await _reviewRepository.AddAsync(review);
            Assert.True(_dbContext.Entry(review.Product).State == Microsoft.EntityFrameworkCore.EntityState.Unchanged);
        }

        [Fact]
        public async void Should_Return_Error_For_Empty_Product() {
            ProductReview review = new ProductReview() {
                Title = "Test",
                Comment = "Test",
                Score = 4,
                ProductRecommended = true
            };

            await Assert.ThrowsAnyAsync<Exception>(() => _reviewRepository.AddAsync(review));
        }

        [Fact]
        public async void Shuod_Return_Error_For_Empty_Title() {
            ProductReview review = new ProductReview() {
                Product = new Product {
                    Id = 1
                },
                Comment = "Test",
                Score = 4,
                ProductRecommended = true
            };

            await _reviewRepository.AddAsync(review);
            await Assert.ThrowsAnyAsync<Exception>(() => _dbContext.SaveChangesAsync());
        }

        [Fact]
        public async void Shuod_Return_Error_For_Empty_Comment() {
            ProductReview review = new ProductReview() {
                Product = new Product {
                    Id = 1
                },
                Title = "Test",
                Score = 4,
                ProductRecommended = true
            };

            await _reviewRepository.AddAsync(review);
            await Assert.ThrowsAnyAsync<Exception>(() => _dbContext.SaveChangesAsync());
        }

        [Fact]
        public async void Should_Returns_Reviews() {
            ProductReview review = new ProductReview() {
                Product = new Product {
                    Id = 1
                },
                Title = "Test",
                Comment = "Test",
                Score = 4,
                ProductRecommended = true
            };

            await _reviewRepository.AddAsync(review);
            await _dbContext.SaveChangesAsync();

            IEnumerable<ProductReview> reviews = await _reviewRepository.GetAllAsync(1);
            Assert.True(reviews.Any());
        }

        [Fact]
        public async void Should_Calculate_Correct_Summery() {
            foreach (var item in Reviews()) {
                await _reviewRepository.AddAsync(item);
            }

            await _dbContext.SaveChangesAsync();

            (double AverageScore, double RecommandationPercentage) = await _reviewRepository.GetSummeryAsync(1);
            Assert.Equal(3, AverageScore);
            Assert.Equal(50, RecommandationPercentage);
        }

        private static IEnumerable<ProductReview> Reviews() {
            Product product = new Product() { Id = 1 };
            yield return new ProductReview() {
                Product = product,
                Title = "Test1",
                Comment = "Test1",
                Score = 4,
                ProductRecommended = true
            };
            yield return new ProductReview() {
                Product = product,
                Title = "Test2",
                Comment = "Test2",
                Score = 2,
                ProductRecommended = false
            };
            yield return new ProductReview() {
                Product = product,
                Title = "Test3",
                Comment = "Test3",
                Score = 5,
                ProductRecommended = true
            };
            yield return new ProductReview() {
                Product = product,
                Title = "Test4",
                Comment = "Test4",
                Score = 1,
                ProductRecommended = false
            };
        }
    }
}
