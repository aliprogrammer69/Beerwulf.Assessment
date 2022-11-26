using BeerWulf.Common.Models;
using BeerWulf.Common.Utils;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Models.Queries;
using BeerWulf.Domain.Services;
using BeerWulf.UI.Api.DTOs;

namespace BeerWulf.UI.Api.Presentores.Impls {
    public class ProductPresentore : IProductPresentore {
        private readonly IProductService _productService;
        private readonly IObjectMapper _mapper;

        public ProductPresentore(IProductService productService,
                                 IObjectMapper mapper) {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<ArrayResult<ProductDto>> SearchAsync(ProductQuery query) {
            ArrayResult<Product> result = await _productService.GetAllAsync(query);
            if (!result.Success)
                return new ArrayResult<ProductDto>(result.Code, result.Message);
            return new ArrayResult<ProductDto>(Common.ResultCode.Ok) {
                Data = _mapper.Map<IEnumerable<ProductDto>>(result.Data)
            };
        }
    }
}
