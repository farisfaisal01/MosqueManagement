using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class paymentDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "paymentAmount",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentCardCVC",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentCardExpireMonth",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentCardExpireYear",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentCardNumber",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentMethod",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentPurpose",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentAmount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "paymentCardCVC",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "paymentCardExpireMonth",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "paymentCardExpireYear",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "paymentCardNumber",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "paymentMethod",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "paymentPurpose",
                table: "Payments");

            migrationBuilder.AddColumn<double>(
                name: "amount",
                table: "Payments",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    donationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donationAmount = table.Column<double>(type: "float", nullable: true),
                    donationSuccess = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.donationId);
                });
        }
    }
}
