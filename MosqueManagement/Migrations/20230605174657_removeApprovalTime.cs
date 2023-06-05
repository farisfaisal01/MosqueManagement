using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class removeApprovalTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "approvalMonth",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "approvalYear",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "feedback",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "approvalMonth",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "approvalYear",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "feedback",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "approvalMonth",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "approvalYear",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "feedback",
                table: "Classes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "approvalMonth",
                table: "Socials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approvalYear",
                table: "Socials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "feedback",
                table: "Socials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approvalMonth",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approvalYear",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "feedback",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approvalMonth",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approvalYear",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "feedback",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
