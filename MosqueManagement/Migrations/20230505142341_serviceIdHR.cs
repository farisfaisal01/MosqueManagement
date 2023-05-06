using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class serviceIdHR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumanResources_Services_serviceId",
                table: "HumanResources");

            migrationBuilder.DropIndex(
                name: "IX_HumanResources_serviceId",
                table: "HumanResources");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "HumanResources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "HumanResources",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HumanResources_serviceId",
                table: "HumanResources",
                column: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HumanResources_Services_serviceId",
                table: "HumanResources",
                column: "serviceId",
                principalTable: "Services",
                principalColumn: "serviceId");
        }
    }
}
