using Microsoft.EntityFrameworkCore;

namespace BeerWulf.Data.Impl.EF.Seed {
    public class SeedHelper {
        private readonly BeerWulfProductReviewDbContext _dbContext;

        public SeedHelper(BeerWulfProductReviewDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void SeedProduct() {
            _dbContext.Products.AddRange(SeedProducts.Products);
            _dbContext.SaveChanges();
        }
    }
}
