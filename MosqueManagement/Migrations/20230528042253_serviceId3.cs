using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class serviceId3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Payments_paymentId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_Userid",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_Userid",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Payments_paymentId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Users_Userid",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Payments_paymentId",
                table: "Socials");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Users_Userid",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_paymentId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_Userid",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_paymentId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_Userid",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Userid",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Classes_paymentId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Userid",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "Classes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentId",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socials_paymentId",
                table: "Socials",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_Userid",
                table: "Socials",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_paymentId",
                table: "Rentals",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_Userid",
                table: "Rentals",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Userid",
                table: "Payments",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_paymentId",
                table: "Classes",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Userid",
                table: "Classes",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Payments_paymentId",
                table: "Classes",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_Userid",
                table: "Classes",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_Userid",
                table: "Payments",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Payments_paymentId",
                table: "Rentals",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Users_Userid",
                table: "Rentals",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Payments_paymentId",
                table: "Socials",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Users_Userid",
                table: "Socials",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
