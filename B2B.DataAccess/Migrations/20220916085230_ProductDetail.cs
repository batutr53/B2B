using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccess.Migrations
{
    public partial class ProductDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Memory",
                table: "ProductDetails",
                newName: "Year");

            migrationBuilder.AddColumn<string>(
                name: "CC",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hp",
                table: "ProductDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kg",
                table: "ProductDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaksSpeed",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CC",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Hp",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Kg",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "MaksSpeed",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "ProductDetails",
                newName: "Memory");
        }
    }
}
