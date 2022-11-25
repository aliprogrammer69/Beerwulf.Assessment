using BeerWulf.Common;
using BeerWulf.Common.Models;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;
using BeerWulf.Domain.Models.Queries;
using BeerWulf.Domain.Services;

namespace BeerWulf.Application.Services {
    public class ProductService : IProductService {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<ArrayResult<Product>> GetAllAsync(ProductQuery query = null) {
            IEnumerable<Product> products = await _productRepository.GetAllAsync(query);
            return new ArrayResult<Product>(ResultCode.Ok) {
                Data = products
            };
        }
    }
}
