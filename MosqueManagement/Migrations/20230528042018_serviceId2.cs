using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class serviceId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Services_serviceId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Services_serviceId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_serviceId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Classes_serviceId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "Classes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socials_serviceId",
                table: "Socials",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_serviceId",
                table: "Classes",
                column: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Services_serviceId",
                table: "Classes",
                column: "serviceId",
                principalTable: "Services",
                principalColumn: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Services_serviceId",
                table: "Socials",
                column: "serviceId",
                principalTable: "Services",
                principalColumn: "serviceId");
        }
    }
}
