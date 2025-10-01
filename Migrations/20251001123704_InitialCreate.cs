using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moo_Arvelous_Coders.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BfirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BphoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bidnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.BuyerId);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    FarmerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Idnumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.FarmerId);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    FarmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PriceBought = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FarmSize = table.Column<double>(type: "float", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FarmerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.FarmId);
                    table.ForeignKey(
                        name: "FK_Farms_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Herds",
                columns: table => new
                {
                    HerdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HerdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cattle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Herdsize = table.Column<int>(type: "int", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    FarmerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herds", x => x.HerdId);
                    table.ForeignKey(
                        name: "FK_Herds_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId");
                    table.ForeignKey(
                        name: "FK_Herds_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "FarmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cattles",
                columns: table => new
                {
                    CattleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfDeath = table.Column<DateOnly>(type: "date", nullable: true),
                    HerdId = table.Column<int>(type: "int", nullable: true),
                    FarmerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cattles", x => x.CattleId);
                    table.ForeignKey(
                        name: "FK_Cattles_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId");
                    table.ForeignKey(
                        name: "FK_Cattles_Herds_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herds",
                        principalColumn: "HerdId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HerdComments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HerdId = table.Column<int>(type: "int", nullable: false),
                    FarmerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HerdComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_HerdComments_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId");
                    table.ForeignKey(
                        name: "FK_HerdComments_Herds_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herds",
                        principalColumn: "HerdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CattleHealthRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CattleId = table.Column<int>(type: "int", nullable: true),
                    RecordDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TreatmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CattleHealthRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_CattleHealthRecords_Cattles_CattleId",
                        column: x => x.CattleId,
                        principalTable: "Cattles",
                        principalColumn: "CattleId");
                });

            migrationBuilder.CreateTable(
                name: "CattlePhotos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CattleId = table.Column<int>(type: "int", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CattlePhotos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_CattlePhotos_Cattles_CattleId",
                        column: x => x.CattleId,
                        principalTable: "Cattles",
                        principalColumn: "CattleId");
                });

            migrationBuilder.CreateTable(
                name: "CattleSaleRecords",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CattleId = table.Column<int>(type: "int", nullable: true),
                    FarmerId = table.Column<int>(type: "int", nullable: true),
                    SaleDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CattleSaleRecords", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_CattleSaleRecords_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CattleSaleRecords_Cattles_CattleId",
                        column: x => x.CattleId,
                        principalTable: "Cattles",
                        principalColumn: "CattleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CattleSaleRecords_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CattleHealthRecords_CattleId",
                table: "CattleHealthRecords",
                column: "CattleId");

            migrationBuilder.CreateIndex(
                name: "IX_CattlePhotos_CattleId",
                table: "CattlePhotos",
                column: "CattleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cattles_FarmerId",
                table: "Cattles",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cattles_HerdId",
                table: "Cattles",
                column: "HerdId");

            migrationBuilder.CreateIndex(
                name: "IX_CattleSaleRecords_BuyerId",
                table: "CattleSaleRecords",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_CattleSaleRecords_CattleId",
                table: "CattleSaleRecords",
                column: "CattleId");

            migrationBuilder.CreateIndex(
                name: "IX_CattleSaleRecords_FarmerId",
                table: "CattleSaleRecords",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_EmailAddress",
                table: "Farmers",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_Idnumber",
                table: "Farmers",
                column: "Idnumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_HerdComments_FarmerId",
                table: "HerdComments",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_HerdComments_HerdId",
                table: "HerdComments",
                column: "HerdId");

            migrationBuilder.CreateIndex(
                name: "IX_Herds_FarmerId",
                table: "Herds",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Herds_FarmId",
                table: "Herds",
                column: "FarmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CattleHealthRecords");

            migrationBuilder.DropTable(
                name: "CattlePhotos");

            migrationBuilder.DropTable(
                name: "CattleSaleRecords");

            migrationBuilder.DropTable(
                name: "HerdComments");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Cattles");

            migrationBuilder.DropTable(
                name: "Herds");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
