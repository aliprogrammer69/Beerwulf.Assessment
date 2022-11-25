namespace BeerWulf.Domain.Models {
    public class ProductReview : Identity<uint> {
        public Product Product { get; set; }
        public string Title { get; set; }
        public byte Score { get; set; }
        public string Comment { get; set; }
        public bool ProductRecommended { get; set; }
    }
}
