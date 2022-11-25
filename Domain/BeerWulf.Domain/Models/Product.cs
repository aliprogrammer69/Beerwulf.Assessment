namespace BeerWulf.Domain.Models {
    public class Product : Identity<uint> {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<ProductReview> Reviews { get; set; }
    }
}
