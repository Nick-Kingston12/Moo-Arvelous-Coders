using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moo_Arvelous_Coders.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUserIdToBuyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Buyers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_IdentityUserId",
                table: "Buyers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_AspNetUsers_IdentityUserId",
                table: "Buyers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_AspNetUsers_IdentityUserId",
                table: "Buyers");

            migrationBuilder.DropIndex(
                name: "IX_Buyers_IdentityUserId",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Buyers");
        }
    }
}
