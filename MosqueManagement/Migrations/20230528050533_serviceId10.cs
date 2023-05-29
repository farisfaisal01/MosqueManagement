using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class serviceId10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Classes_ClassformId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Rentals_RentalformId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Socials_SocialformId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ClassformId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_RentalformId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_SocialformId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ClassformId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "RentalformId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "SocialformId",
                table: "Schedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassformId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentalformId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocialformId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassformId",
                table: "Schedules",
                column: "ClassformId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RentalformId",
                table: "Schedules",
                column: "RentalformId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SocialformId",
                table: "Schedules",
                column: "SocialformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Classes_ClassformId",
                table: "Schedules",
                column: "ClassformId",
                principalTable: "Classes",
                principalColumn: "formId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Rentals_RentalformId",
                table: "Schedules",
                column: "RentalformId",
                principalTable: "Rentals",
                principalColumn: "formId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Socials_SocialformId",
                table: "Schedules",
                column: "SocialformId",
                principalTable: "Socials",
                principalColumn: "formId");
        }
    }
}
