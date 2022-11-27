using BeerWulf.Data.Impl.EF.Repositories;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Models.Queries;

using Microsoft.EntityFrameworkCore;

namespace BeerWulf.Test.UnitTest.RepositoryTests {
    public class ProductRepositoryTests : BaseRepositoryTest {
        private readonly IProductRepository _productRepository;
        public ProductRepositoryTests() {
            _productRepository = new ProductRepository(_dbContext);
        }

        [Fact]
        public async void Should_Add_Product() {
            Product product = new Product() {
                Description = "Test",
                Name = "Test",
                Price = 10,
                Id = 10
            };

            await _productRepository.AddAsync(product);
            Assert.True(_dbContext.Entry(product).State == EntityState.Added);
        }


        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(5, false)]
        [InlineData(4, true)]
        public async void Product_Existence_Should_Be_Currect(uint productId, bool exists) {
            bool result = await _productRepository.ExistsAsync(productId);
            Assert.Equal(result, exists);
        }


        [Theory]
        [MemberData(nameof(ProductQueries))]
        public async void Query_Should_Be_Currect(ProductQuery query, IEnumerable<uint> expectedProductIds) {
            IEnumerable<Product> products = await _productRepository.GetAllAsync(query);
            Assert.Equal(products?.Count() ?? 0, expectedProductIds?.Count() ?? 0);
            Assert.True(products.All(p => expectedProductIds.Any(e => e == p.Id)));
        }


        public static IEnumerable<object[]> ProductQueries {
            get => new List<object[]>(4) {
                new object[2]{new ProductQuery() { Id = 1},new uint[1] {1} },
                new object[2]{null, new uint[4] {1,2,3,4} },
                new object[2]{new ProductQuery {Name = "Tiger" }, new uint[2] {2,3} }
            };
        }
    }
}
