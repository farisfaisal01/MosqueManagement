using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class serviceId11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "formId",
                table: "Socials",
                newName: "socialId");

            migrationBuilder.RenameColumn(
                name: "formId",
                table: "Rentals",
                newName: "rentalId");

            migrationBuilder.RenameColumn(
                name: "formId",
                table: "Classes",
                newName: "classId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "socialId",
                table: "Socials",
                newName: "formId");

            migrationBuilder.RenameColumn(
                name: "rentalId",
                table: "Rentals",
                newName: "formId");

            migrationBuilder.RenameColumn(
                name: "classId",
                table: "Classes",
                newName: "formId");
        }
    }
}
