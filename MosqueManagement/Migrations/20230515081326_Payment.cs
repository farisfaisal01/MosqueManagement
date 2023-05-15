using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "paymentSuccess",
                table: "Payments",
                newName: "paymentName");

            migrationBuilder.AddColumn<string>(
                name: "paymentContact",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentEmail",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentContact",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "paymentEmail",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "paymentName",
                table: "Payments",
                newName: "paymentSuccess");
        }
    }
}
