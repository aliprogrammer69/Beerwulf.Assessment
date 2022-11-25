using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeerWulf.Data.Impl.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Score = table.Column<byte>(type: "tinyint", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    ProductRecommended = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Product",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "A crisp and refreshing session IPA with fruity notes and hints of grass and tea. Fresh and frisky with a clean bitter finish exactly how a session IPA should be.", "Fourpure Session IPA - 2L SUB Keg", 11.99m },
                    { 2L, "This beer was first brewed in Singapore in 1932, so is made for hotter temperatures and is bound to help satisfy your thirst. The recipe includes rice, malted barley and American Zeus hops, so has a variety of flavours to please the palette. Lagers are often the go-to when pouring pints for a group of friends, so next time you have people over, some Tiger will bring smiles all around.", "Tiger - 2L SUB Keg", 9.34m },
                    { 3L, "This beer was first brewed in Singapore in 1932, so is made for hotter temperatures and is bound to help satisfy your thirst. The recipe includes rice, malted barley and American Zeus hops, so has a variety of flavours to please the palette. Lagers are often the go-to when pouring pints for a group of friends, so next time you have people over, some Tiger will bring smiles all around.", "This beer was first brewed in Singapore in 1932, so is made for hotter temperatures and is bound to help satisfy your thirst. The recipe includes rice, malted barley and American Zeus hops, so has a variety of flavours to please the palette. Lagers are often the go-to when pouring pints for a group of friends, so next time you have people over, some Tiger will bring smiles all around.", 26.24m },
                    { 4L, "Villacher Marzen is a very drinkable lager where the malty and toasted bread-like taste and smell is the highlight of the beer. The presence of hops is not noticeable in the smell and taste, but the beer does have a moderate hop bitterness. This beer has a radiant, golden yellow colour and fine-bubble foam whilst being incredibly refreshing and sparkling to taste. It was awarded the golden DLG seal in 2014 and 2015", "Villacher Märzen - 8L BLADE Keg", 28.49m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                schema: "Product",
                table: "ProductReviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReviews",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Product");
        }
    }
}
