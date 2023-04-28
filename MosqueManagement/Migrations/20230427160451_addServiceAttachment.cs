using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class addServiceAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "serviceAttachment",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "serviceAttachment",
                table: "Services");
        }
    }
}
