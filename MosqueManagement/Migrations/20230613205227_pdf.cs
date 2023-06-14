using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class pdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "socialAttachmentPath",
                table: "Socials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rentalAttachmentPath",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "classImagePath",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "socialAttachmentPath",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "rentalAttachmentPath",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "classImagePath",
                table: "Classes");
        }
    }
}
