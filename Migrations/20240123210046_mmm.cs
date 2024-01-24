using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lunettes.Migrations
{
    /// <inheritdoc />
    public partial class mmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PanierId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Panier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Panier_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PanierId",
                table: "Products",
                column: "PanierId");

            migrationBuilder.CreateIndex(
                name: "IX_Panier_ProductsId",
                table: "Panier",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Panier_PanierId",
                table: "Products",
                column: "PanierId",
                principalTable: "Panier",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Panier_PanierId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Panier");

            migrationBuilder.DropIndex(
                name: "IX_Products_PanierId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PanierId",
                table: "Products");
        }
    }
}
