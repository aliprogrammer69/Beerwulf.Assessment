namespace BeerWulf.Data {
    public interface IUnitOfWork {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
