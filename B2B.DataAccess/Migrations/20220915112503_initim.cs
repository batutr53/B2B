using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccess.Migrations
{
    public partial class initim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductImage",
                columns: table => new
                {
                    ProductImagesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductImage", x => new { x.ProductImagesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductImage_ProductImages_ProductImagesId",
                        column: x => x.ProductImagesId,
                        principalTable: "ProductImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductImage_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bajaj" },
                    { 2, "Ducati" },
                    { 3, "Honda" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Motorsiklet" },
                    { 2, "Otomotiv" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pulsar" },
                    { 2, "Dominar" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "Color", "Memory" },
                values: new object[,]
                {
                    { 1, "Black", null },
                    { 2, "Red", null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagesUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://www.ekuralkan.com/Data/EditorFiles/kuralkan/htlm_dosyalar/rs200/banner-rs200.jpg", 0 },
                    { 2, "https://www.ekuralkan.com/Data/EditorFiles/360/dominar%20D400%20EURO%205%20aksesuarl%C4%B1/k15.png", 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "ModelId", "Name", "Price", "ProductDetailId" },
                values: new object[] { 1, 1, 1, "HIZ TUTKUNUZUN YENİ PARTNERİ Tutkunuzu hızlandıracak,hız tutkunuza partner olacak Pulsar RS 200 ile tanışın.RS 200 ile yolculuklarınız hızlanacak, tutkunuz aşka dönüşecek.Pulsar RS 200 Hız tutkunuzun yeni partneri", 1, "Bajaj Pulsar Rs 200 2022", 73505m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "ModelId", "Name", "Price", "ProductDetailId" },
                values: new object[] { 2, 1, 1, "Dominar 400'ün 29.4kW güç ve 35 Nm tork üretebilen canavar gücündeki motoru ile yol maceranıza hazırlanın ve yola koyulun.", 2, "Bajaj Pulsar Dominar Tur 400", 118000m, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_BrandModel_ModelsId",
                table: "BrandModel",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductImage_ProductsId",
                table: "ProductProductImage",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                column: "ProductDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandModel");

            migrationBuilder.DropTable(
                name: "ProductProductImage");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ProductDetails");
        }
    }
}
