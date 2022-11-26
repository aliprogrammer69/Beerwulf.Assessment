using AutoMapper;

using BeerWulf.Bootstrapper;
using BeerWulf.Common.Utils;
using BeerWulf.Domain.Models;
using BeerWulf.UI.Api.DTOs;
using BeerWulf.UI.Api.Presentores;
using BeerWulf.UI.Api.Presentores.Impls;

namespace BeerWulf.UI.Api.Infra
{
    public class ApiServiceCollectionManager : DefaultServiceCollectionManager
    {

        public override IServiceCollectionManager RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IProductPresentore, ProductPresentore>()
                   .AddScoped<IProductReviewPresentore, ProductReviewPresentore>();
            return base.RegisterServices(service);
        }

        public override IServiceCollectionManager RegisterUtils(IServiceCollection service)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(ConfigureMapper);
            IMapper mapper = mapperConfiguration.CreateMapper();

            service.AddSingleton<IObjectMapper, AutoMapperWrapper>()
                   .AddSingleton(mapper);

            return base.RegisterUtils(service);
        }

        #region Private Methods
        private void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<Product, ProductDto>();
            config.CreateMap<ProductReview, ReviewDto>();
        }
        #endregion
    }
}
