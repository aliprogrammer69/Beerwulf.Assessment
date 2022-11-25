using Microsoft.EntityFrameworkCore;

namespace BeerWulf.Data.Impl.EF {
    public class UnitOfWork : IUnitOfWork {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) {
            _dbContext = dbContext;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);

    }
}
