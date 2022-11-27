using BeerWulf.Data.Impl.EF;

namespace BeerWulf.Test.UnitTest.RepositoryTests {
    public abstract class BaseRepositoryTest {
        protected readonly BeerWulfProductReviewDbContext _dbContext;

        public BaseRepositoryTest() {
            _dbContext = DbContextBuilder.GenerateDbContext();

        }
    }
}
