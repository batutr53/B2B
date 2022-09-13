using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccess.Migrations
{
    public partial class ModelsBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Models_ModelId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_ModelId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "ProductImageId",
                table: "Products",
                newName: "ModelId");

            migrationBuilder.CreateTable(
                name: "BrandModel",
                columns: table => new
                {
                    BrandsId = table.Column<int>(type: "int", nullable: false),
                    ModelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandModel", x => new { x.BrandsId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_BrandModel_Brands_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandModel_Models_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandModel_ModelsId",
                table: "BrandModel",
                column: "ModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BrandModel");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Products",
                newName: "ProductImageId");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ModelId",
                table: "Brands",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Models_ModelId",
                table: "Brands",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
