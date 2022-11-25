using BeerWulf.Data.Impl.EF;
using BeerWulf.Data.Impl.EF.Repositories;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;

namespace BeerWulf.Test.UnitTest.RepositoryTests {
    public class ReviewRepoositoryTests {
        private readonly BeerWulfProductReviewDbContext _dbContext;
        private readonly IReviewRepository _reviewRepository;
        public ReviewRepoositoryTests() {
            _dbContext = DbContextBuilder.GenerateDbContext();
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
            await _dbContext.SaveChangesAsync();

            IEnumerable<ProductReview> reviews = await _reviewRepository.GetAllAsync(1);
            Assert.True(reviews.Any());
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
    }
}
