namespace BeerWulf.UI.Api.DTOs {
    public class ReviewDto : DtoBase<uint> {
        public string Title { get; set; }
        public byte Score { get; set; }
        public string Comment { get; set; }
        public bool ProductRecommended { get; set; }
    }
}
