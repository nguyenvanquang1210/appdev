using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FptBook.Migrations
{
    public partial class quantitycart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Book_BookIsbn",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Book_BookIsbn",
                table: "Cart",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Book_BookIsbn",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cart");

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Book_BookIsbn",
                table: "Cart",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
