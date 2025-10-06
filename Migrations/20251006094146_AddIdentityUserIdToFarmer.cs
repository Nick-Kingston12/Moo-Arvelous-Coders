using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moo_Arvelous_Coders.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUserIdToFarmer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Farmers");
        }
    }
}
