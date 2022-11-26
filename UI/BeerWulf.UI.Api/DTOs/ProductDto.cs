namespace BeerWulf.UI.Api.DTOs {
    public class ProductDto : DtoBase<uint> {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
