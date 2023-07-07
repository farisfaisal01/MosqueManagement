using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class payfilr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "address",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "gender",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "ic",
            //    table: "Users");

            //migrationBuilder.RenameColumn(
            //    name: "id",
            //    table: "Users",
            //    newName: "userId");

            migrationBuilder.AddColumn<string>(
                name: "paymentImagePath",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentImagePath",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ic",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
