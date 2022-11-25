using BeerWulf.Domain.Models;

namespace BeerWulf.Data.Impl.EF.Seed {
    internal static class SeedProducts {
        static SeedProducts() {
            Products = new List<Product>() {
                new Product() {
                    Id = 1,
                    Name = "Fourpure Session IPA - 2L SUB Keg",
                    Description = "A crisp and refreshing session IPA with fruity notes and hints of grass and tea. Fresh and frisky with a clean bitter finish exactly how a session IPA should be.",
                    Price = 11.99M
                },
                new Product() {
                    Id = 2,
                    Name = "Tiger - 2L SUB Keg",
                    Description = "This beer was first brewed in Singapore in 1932, so is made for hotter temperatures and is bound to help satisfy your thirst. The recipe includes rice, malted barley and American Zeus hops, so has a variety of flavours to please the palette. Lagers are often the go-to when pouring pints for a group of friends, so next time you have people over, some Tiger will bring smiles all around.",
                    Price = 9.34M
                },
                new Product() {
                    Id = 3,
                    Name = "This beer was first brewed in Singapore in 1932, so is made for hotter temperatures and is bound to help satisfy your thirst. The recipe includes rice, malted barley and American Zeus hops, so has a variety of flavours to please the palette. Lagers are often the go-to when pouring pints for a group of friends, so next time you have people over, some Tiger will bring smiles all around.",
                    Description = "This beer was first brewed in Singapore in 1932, so is made for hotter temperatures and is bound to help satisfy your thirst. The recipe includes rice, malted barley and American Zeus hops, so has a variety of flavours to please the palette. Lagers are often the go-to when pouring pints for a group of friends, so next time you have people over, some Tiger will bring smiles all around.",
                    Price = 26.24M
                },
                new Product() {
                    Id = 4,
                    Name = "Villacher Märzen - 8L BLADE Keg",
                    Description = "Villacher Marzen is a very drinkable lager where the malty and toasted bread-like taste and smell is the highlight of the beer. The presence of hops is not noticeable in the smell and taste, but the beer does have a moderate hop bitterness. This beer has a radiant, golden yellow colour and fine-bubble foam whilst being incredibly refreshing and sparkling to taste. It was awarded the golden DLG seal in 2014 and 2015",
                    Price = 28.49M
                }
            };
        }

        public static IEnumerable<Product> Products { get; private set; }
    }
}
