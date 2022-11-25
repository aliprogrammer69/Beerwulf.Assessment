using BeerWulf.Application.Services;
using BeerWulf.Application.Services.Validations;
using BeerWulf.Application.Services.Validations.Impls;
using BeerWulf.Data;
using BeerWulf.Data.Impl.EF;
using BeerWulf.Data.Impl.EF.Repositories;
using BeerWulf.Data.Impl.EF.Seed;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Services;

using Microsoft.Extensions.DependencyInjection;

namespace BeerWulf.Bootstrapper {
    public class DefaultServiceCollectionManager : IServiceCollectionManager {
        public IServiceCollectionManager RegisterRepositories(IServiceCollection service) {
            service.AddScoped<IProductRepository, ProductRepository>()
                   .AddScoped<IReviewRepository, ReviewRepository>()
                   .AddScoped<IUnitOfWork, UnitOfWork>()
                   .AddScoped<SeedHelper>();
            return this;
        }

        public IServiceCollectionManager RegisterServices(IServiceCollection service) {
            service.AddScoped<IProductService, ProductService>()
                   .AddScoped<IReviewService, ReviewService>()
                   .AddScoped<IProductReviewValidatore, ProductReviewValidatore>();
            return this;
        }
    }
}
