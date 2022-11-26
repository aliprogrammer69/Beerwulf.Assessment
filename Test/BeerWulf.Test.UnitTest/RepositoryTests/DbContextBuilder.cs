using BeerWulf.Data.Impl.EF;
using BeerWulf.Data.Impl.EF.Seed;

using Microsoft.EntityFrameworkCore;

namespace BeerWulf.Test.UnitTest.RepositoryTests {
    public static class DbContextBuilder {
        public static BeerWulfProductReviewDbContext GenerateDbContext() {
            DbContextOptionsBuilder<BeerWulfProductReviewDbContext> builder = new DbContextOptionsBuilder<BeerWulfProductReviewDbContext>();
            builder.UseInMemoryDatabase($"BeerWulfDb_{Guid.NewGuid()}");

            using(BeerWulfProductReviewDbContext seedContext = new BeerWulfProductReviewDbContext(builder.Options)) {
                SeedHelper seedHelper = new SeedHelper(seedContext);
                seedHelper.SeedProduct();
            }

            return new BeerWulfProductReviewDbContext(builder.Options); 
        }
    }
}
