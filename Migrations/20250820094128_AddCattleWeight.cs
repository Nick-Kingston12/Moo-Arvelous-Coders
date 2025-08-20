using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moo_Arvelous_Coders.Migrations
{
    /// <inheritdoc />
    public partial class AddCattleWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Farmer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Cattle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BPassword",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Cattle");

            migrationBuilder.DropColumn(
                name: "BPassword",
                table: "Buyer");
        }
    }
}
