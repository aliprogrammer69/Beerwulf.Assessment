using Microsoft.Extensions.DependencyInjection;

namespace BeerWulf.Bootstrapper {
    public interface IServiceCollectionManager {
        IServiceCollectionManager RegisterRepositories(IServiceCollection service);
        IServiceCollectionManager RegisterServices(IServiceCollection service);
    }
}
