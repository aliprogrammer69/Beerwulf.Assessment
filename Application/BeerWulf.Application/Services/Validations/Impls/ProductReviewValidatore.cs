﻿using BeerWulf.Common;
using BeerWulf.Common.Models;
using BeerWulf.Data.Repositories;
using BeerWulf.Domain.Models;

namespace BeerWulf.Application.Services.Validations.Impls {
    public class ProductReviewValidatore : IProductReviewValidatore {
        private readonly IProductRepository _productRepository;

        public ProductReviewValidatore(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<Result> AddAsync(ProductReview review) {
            if (string.IsNullOrWhiteSpace(review.Title) || string.IsNullOrWhiteSpace(review.Comment))
                return new Result(ResultCode.BadRequest, "Title and comment can't be empty");

            if (review.Product == null)
                return new Result(ResultCode.BadRequest, "Product can't be null");

            bool productExists = await _productRepository.ExistsAsync(review.Product.Id);
            if (!productExists)
                return new Result(ResultCode.BadRequest, "Product not exists");

            return new Result(ResultCode.Ok);
        }
    }
}
