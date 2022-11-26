using BeerWulf.Common.Models;
using BeerWulf.Domain.Models.Queries;
using BeerWulf.UI.Api.DTOs;

namespace BeerWulf.UI.Api.Presentores {
    public interface IProductPresentore {
        Task<ArrayResult<ProductDto>> SearchAsync(ProductQuery query);
    }
}
