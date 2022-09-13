using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccess.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                columns: new[] { "Id", "ImagesUrl" },
                values: new object[,]
                {
                    { 1, "https://www.ekuralkan.com/Data/EditorFiles/kuralkan/htlm_dosyalar/rs200/banner-rs200.jpg" },
                    { 2, "https://www.ekuralkan.com/Data/EditorFiles/360/dominar%20D400%20EURO%205%20aksesuarl%C4%B1/k15.png" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "ModelId", "Name" },
                values: new object[] { 1, 1, "Bajaj" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "ModelId", "Name" },
                values: new object[] { 2, 2, "Ducati" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "ModelId", "Name" },
                values: new object[] { 3, 1, "Honda" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "Name", "Price", "ProductDetailId", "ProductImageId" },
                values: new object[] { 1, 1, 1, "HIZ TUTKUNUZUN YENİ PARTNERİ Tutkunuzu hızlandıracak,hız tutkunuza partner olacak Pulsar RS 200 ile tanışın.RS 200 ile yolculuklarınız hızlanacak, tutkunuz aşka dönüşecek.Pulsar RS 200 Hız tutkunuzun yeni partneri", "Bajaj Pulsar Rs 200 2022", 73505m, 1, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "Name", "Price", "ProductDetailId", "ProductImageId" },
                values: new object[] { 2, 1, 1, "Dominar 400'ün 29.4kW güç ve 35 Nm tork üretebilen canavar gücündeki motoru ile yol maceranıza hazırlanın ve yola koyulun.", "Bajaj Pulsar Dominar Tur 400", 118000m, 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
