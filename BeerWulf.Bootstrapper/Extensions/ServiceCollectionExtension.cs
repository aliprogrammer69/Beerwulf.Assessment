using BeerWulf.Data.Impl.EF;
using BeerWulf.Data.Impl.EF.Seed;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BeerWulf.Bootstrapper.Extensions {
    public static class ServiceCollectionExtension {
        public static IServiceCollection AddBeerWolfApi(this IServiceCollection services, IServiceCollectionManager manager = null) {
            if (manager == null)
                manager = new DefaultServiceCollectionManager();

            manager.RegisterServices(services)
                   .RegisterRepositories(services);

            return services;
        }

        public static IServiceCollection AddBeerWulfDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> options) {
            services.AddDbContext<BeerWulfProductReviewDbContext>(options);
            return services;
        }

        public static IServiceProvider InitializeBeerWulfMockProducts(this IServiceProvider service) {
            using (IServiceScope scope = service.CreateScope()) {
                scope.ServiceProvider.GetService<SeedHelper>().SeedProduct();
            }
            return service;
        }
    }
}
