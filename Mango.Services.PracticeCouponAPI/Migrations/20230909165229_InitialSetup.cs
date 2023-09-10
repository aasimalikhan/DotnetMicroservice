using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.PracticeCouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    ShoeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoePrice = table.Column<int>(type: "int", nullable: false),
                    ShoeSalePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.ShoeId);
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "ShoeId", "ShoeBrand", "ShoePrice", "ShoeSalePrice" },
                values: new object[,]
                {
                    { 1, "adidas", 1200, 1000 },
                    { 2, "adidas", 1300, 1200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoes");
        }
    }
}
