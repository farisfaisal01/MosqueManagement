using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class removeschedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Schedules_scheduleId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Schedules_scheduleId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Schedules_scheduleId",
                table: "Socials");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Socials_scheduleId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_scheduleId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Classes_scheduleId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "scheduleId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "scheduleId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "scheduleId",
                table: "Classes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "scheduleId",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "scheduleId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "scheduleId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    scheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    occupied = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.scheduleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Socials_scheduleId",
                table: "Socials",
                column: "scheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_scheduleId",
                table: "Rentals",
                column: "scheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_scheduleId",
                table: "Classes",
                column: "scheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Schedules_scheduleId",
                table: "Classes",
                column: "scheduleId",
                principalTable: "Schedules",
                principalColumn: "scheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Schedules_scheduleId",
                table: "Rentals",
                column: "scheduleId",
                principalTable: "Schedules",
                principalColumn: "scheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Schedules_scheduleId",
                table: "Socials",
                column: "scheduleId",
                principalTable: "Schedules",
                principalColumn: "scheduleId");
        }
    }
}
