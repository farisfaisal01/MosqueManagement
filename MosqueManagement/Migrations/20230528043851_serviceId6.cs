using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class serviceId6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "serviceName",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "serviceName",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "serviceName",
                table: "Classes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "serviceName",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "serviceName",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "serviceName",
                table: "Classes");
        }
    }
}
