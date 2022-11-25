using BeerWulf.Data.Impl.EF;
using BeerWulf.Data.Impl.EF.Seed;

using Microsoft.EntityFrameworkCore;

namespace BeerWulf.Test.UnitTest.RepositoryTests {
    public static class DbContextBuilder {
        public static BeerWulfProductReviewDbContext GenerateDbContext() {
            DbContextOptionsBuilder<BeerWulfProductReviewDbContext> builder = new DbContextOptionsBuilder<BeerWulfProductReviewDbContext>();
            builder.UseInMemoryDatabase("BeerWulfDb");

            BeerWulfProductReviewDbContext dbContext = new BeerWulfProductReviewDbContext(builder.Options);
            if (!dbContext.Products.Any()) {
                SeedHelper seedHelper = new SeedHelper(dbContext);
                seedHelper.SeedProduct();
                dbContext = new BeerWulfProductReviewDbContext(builder.Options); // Generate new scope
            }

            return dbContext;
        }
    }
}
