using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class serviceId4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "paymentId",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Socials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socials_paymentId",
                table: "Socials",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_serviceId",
                table: "Socials",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_userId",
                table: "Socials",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_paymentId",
                table: "Rentals",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_userId",
                table: "Rentals",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_paymentId",
                table: "Classes",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_serviceId",
                table: "Classes",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_userId",
                table: "Classes",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Payments_paymentId",
                table: "Classes",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Services_serviceId",
                table: "Classes",
                column: "serviceId",
                principalTable: "Services",
                principalColumn: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_userId",
                table: "Classes",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Payments_paymentId",
                table: "Rentals",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Users_userId",
                table: "Rentals",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Payments_paymentId",
                table: "Socials",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Services_serviceId",
                table: "Socials",
                column: "serviceId",
                principalTable: "Services",
                principalColumn: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Users_userId",
                table: "Socials",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Payments_paymentId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Services_serviceId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_userId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Payments_paymentId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Users_userId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Payments_paymentId",
                table: "Socials");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Services_serviceId",
                table: "Socials");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Users_userId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_paymentId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_serviceId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_userId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_paymentId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_userId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Classes_paymentId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_serviceId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_userId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Classes");
        }
    }
}
