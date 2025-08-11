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
                name: "Buyer",
                columns: table => new
                {
                    BuyerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BIDNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Buyer__4B81C1CA078A2677", x => x.BuyerID);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    FarmerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Farmer__731B88E8CB2BC6CA", x => x.FarmerID);
                });

            migrationBuilder.CreateTable(
                name: "Farm",
                columns: table => new
                {
                    FarmID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PriceBought = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FarmSize = table.Column<double>(type: "float", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FarmerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Farm__ED7BBA99F98F561A", x => x.FarmID);
                    table.ForeignKey(
                        name: "FK__Farm__FarmerID__3B75D760",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Herd",
                columns: table => new
                {
                    HerdID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HerdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cattle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Herdsize = table.Column<int>(type: "int", nullable: false),
                    FarmID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FarmerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Herd__0889874A8A2B7728", x => x.HerdID);
                    table.ForeignKey(
                        name: "FK__Herd__FarmID__3E52440B",
                        column: x => x.FarmID,
                        principalTable: "Farm",
                        principalColumn: "FarmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Herd__FarmerID__3F466844",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                });

            migrationBuilder.CreateTable(
                name: "Cattle",
                columns: table => new
                {
                    CattleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Health = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfDeath = table.Column<DateOnly>(type: "date", nullable: true),
                    HerdID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FarmerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cattle__E375C63CBAD731FD", x => x.CattleID);
                    table.ForeignKey(
                        name: "FK__Cattle__FarmerID__44FF419A",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                    table.ForeignKey(
                        name: "FK__Cattle__HerdID__440B1D61",
                        column: x => x.HerdID,
                        principalTable: "Herd",
                        principalColumn: "HerdID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HerdComment",
                columns: table => new
                {
                    CommentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HerdID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HerdComm__C3B4DFAA66060F54", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK__HerdComme__Farme__5629CD9C",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                    table.ForeignKey(
                        name: "FK__HerdComme__HerdI__5535A963",
                        column: x => x.HerdID,
                        principalTable: "Herd",
                        principalColumn: "HerdID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CattleHealthRecord",
                columns: table => new
                {
                    RecordID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CattleID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecordDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TreatmentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CattleHe__FBDF78C921E20F58", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK__CattleHea__Cattl__4AB81AF0",
                        column: x => x.CattleID,
                        principalTable: "Cattle",
                        principalColumn: "CattleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CattlePhoto",
                columns: table => new
                {
                    PhotoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CattleID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhotoURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CattlePh__21B7B5826EA21737", x => x.PhotoID);
                    table.ForeignKey(
                        name: "FK__CattlePho__Cattl__47DBAE45",
                        column: x => x.CattleID,
                        principalTable: "Cattle",
                        principalColumn: "CattleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CattleSaleRecord",
                columns: table => new
                {
                    SaleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CattleID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FarmerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SaleDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    BuyerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CattleSa__1EE3C41F136A9DDC", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK__CattleSal__Buyer__52593CB8",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__CattleSal__Cattl__5070F446",
                        column: x => x.CattleID,
                        principalTable: "Cattle",
                        principalColumn: "CattleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CattleSal__Farme__5165187F",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Buyer__218A515C8481D745",
                table: "Buyer",
                column: "BIDNumber",
                unique: true,
                filter: "[BIDNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cattle_FarmerID",
                table: "Cattle",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Cattle_HerdID",
                table: "Cattle",
                column: "HerdID");

            migrationBuilder.CreateIndex(
                name: "IX_CattleHealthRecord_CattleID",
                table: "CattleHealthRecord",
                column: "CattleID");

            migrationBuilder.CreateIndex(
                name: "IX_CattlePhoto_CattleID",
                table: "CattlePhoto",
                column: "CattleID");

            migrationBuilder.CreateIndex(
                name: "IX_CattleSaleRecord_BuyerID",
                table: "CattleSaleRecord",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_CattleSaleRecord_CattleID",
                table: "CattleSaleRecord",
                column: "CattleID");

            migrationBuilder.CreateIndex(
                name: "IX_CattleSaleRecord_FarmerID",
                table: "CattleSaleRecord",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Farm_FarmerID",
                table: "Farm",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Farmer__49A147408D2FB0FE",
                table: "Farmer",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Farmer__564DB08AE2C54990",
                table: "Farmer",
                column: "IDNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Herd_FarmerID",
                table: "Herd",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Herd_FarmID",
                table: "Herd",
                column: "FarmID");

            migrationBuilder.CreateIndex(
                name: "IX_HerdComment_FarmerID",
                table: "HerdComment",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_HerdComment_HerdID",
                table: "HerdComment",
                column: "HerdID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CattleHealthRecord");

            migrationBuilder.DropTable(
                name: "CattlePhoto");

            migrationBuilder.DropTable(
                name: "CattleSaleRecord");

            migrationBuilder.DropTable(
                name: "HerdComment");

            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Cattle");

            migrationBuilder.DropTable(
                name: "Herd");

            migrationBuilder.DropTable(
                name: "Farm");

            migrationBuilder.DropTable(
                name: "Farmer");
        }
    }
}
