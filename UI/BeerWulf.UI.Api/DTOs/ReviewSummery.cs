namespace BeerWulf.UI.Api.DTOs {
    public class ReviewSummery {
        public ReviewSummery(double avarageScore, double recommandationPercentage) {
            AvarageScore = avarageScore;
            RecommandationPercentage = recommandationPercentage;
        }

        public double AvarageScore { get; set; }
        public double RecommandationPercentage { get; set; }
    }
}
