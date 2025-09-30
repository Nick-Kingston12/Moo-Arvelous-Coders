using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moo_Arvelous_Coders.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Cattle__FarmerID__44FF419A",
                table: "Cattle");

            migrationBuilder.DropForeignKey(
                name: "FK__Cattle__HerdID__440B1D61",
                table: "Cattle");

            migrationBuilder.DropForeignKey(
                name: "FK__CattleHea__Cattl__4AB81AF0",
                table: "CattleHealthRecord");

            migrationBuilder.DropForeignKey(
                name: "FK__CattlePho__Cattl__47DBAE45",
                table: "CattlePhoto");

            migrationBuilder.DropForeignKey(
                name: "FK__CattleSal__Buyer__52593CB8",
                table: "CattleSaleRecord");

            migrationBuilder.DropForeignKey(
                name: "FK__CattleSal__Cattl__5070F446",
                table: "CattleSaleRecord");

            migrationBuilder.DropForeignKey(
                name: "FK__CattleSal__Farme__5165187F",
                table: "CattleSaleRecord");

            migrationBuilder.DropForeignKey(
                name: "FK__Farm__FarmerID__3B75D760",
                table: "Farm");

            migrationBuilder.DropForeignKey(
                name: "FK__Herd__FarmID__3E52440B",
                table: "Herd");

            migrationBuilder.DropForeignKey(
                name: "FK__Herd__FarmerID__3F466844",
                table: "Herd");

            migrationBuilder.DropForeignKey(
                name: "FK__HerdComme__Farme__5629CD9C",
                table: "HerdComment");

            migrationBuilder.DropForeignKey(
                name: "FK__HerdComme__HerdI__5535A963",
                table: "HerdComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__HerdComm__C3B4DFAA66060F54",
                table: "HerdComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Herd__0889874A8A2B7728",
                table: "Herd");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Farmer__731B88E8CB2BC6CA",
                table: "Farmer");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Farm__ED7BBA99F98F561A",
                table: "Farm");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CattleSa__1EE3C41F136A9DDC",
                table: "CattleSaleRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CattlePh__21B7B5826EA21737",
                table: "CattlePhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CattleHe__FBDF78C921E20F58",
                table: "CattleHealthRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Cattle__E375C63CBAD731FD",
                table: "Cattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Buyer__4B81C1CA078A2677",
                table: "Buyer");

            migrationBuilder.DropIndex(
                name: "UQ__Buyer__218A515C8481D745",
                table: "Buyer");

            migrationBuilder.RenameTable(
                name: "HerdComment",
                newName: "HerdComments");

            migrationBuilder.RenameTable(
                name: "Herd",
                newName: "Herds");

            migrationBuilder.RenameTable(
                name: "Farmer",
                newName: "Farmers");

            migrationBuilder.RenameTable(
                name: "Farm",
                newName: "Farms");

            migrationBuilder.RenameTable(
                name: "CattleSaleRecord",
                newName: "CattleSaleRecords");

            migrationBuilder.RenameTable(
                name: "CattlePhoto",
                newName: "CattlePhotos");

            migrationBuilder.RenameTable(
                name: "CattleHealthRecord",
                newName: "CattleHealthRecords");

            migrationBuilder.RenameTable(
                name: "Cattle",
                newName: "Cattles");

            migrationBuilder.RenameTable(
                name: "Buyer",
                newName: "Buyers");

            migrationBuilder.RenameColumn(
                name: "HerdID",
                table: "HerdComments",
                newName: "HerdId");

            migrationBuilder.RenameColumn(
                name: "FarmerID",
                table: "HerdComments",
                newName: "FarmerId");

            migrationBuilder.RenameColumn(
                name: "CommentID",
                table: "HerdComments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_HerdComment_HerdID",
                table: "HerdComments",
                newName: "IX_HerdComments_HerdId");

            migrationBuilder.RenameIndex(
                name: "IX_HerdComment_FarmerID",
                table: "HerdComments",
                newName: "IX_HerdComments_FarmerId");

            migrationBuilder.RenameColumn(
                name: "FarmerID",
                table: "Herds",
                newName: "FarmerId");

            migrationBuilder.RenameColumn(
                name: "FarmID",
                table: "Herds",
                newName: "FarmId");

            migrationBuilder.RenameColumn(
                name: "HerdID",
                table: "Herds",
                newName: "HerdId");

            migrationBuilder.RenameIndex(
                name: "IX_Herd_FarmID",
                table: "Herds",
                newName: "IX_Herds_FarmId");

            migrationBuilder.RenameIndex(
                name: "IX_Herd_FarmerID",
                table: "Herds",
                newName: "IX_Herds_FarmerId");

            migrationBuilder.RenameColumn(
                name: "IDNumber",
                table: "Farmers",
                newName: "Idnumber");

            migrationBuilder.RenameColumn(
                name: "FarmerID",
                table: "Farmers",
                newName: "FarmerId");

            migrationBuilder.RenameIndex(
                name: "UQ__Farmer__564DB08AE2C54990",
                table: "Farmers",
                newName: "IX_Farmers_Idnumber");

            migrationBuilder.RenameIndex(
                name: "UQ__Farmer__49A147408D2FB0FE",
                table: "Farmers",
                newName: "IX_Farmers_EmailAddress");

            migrationBuilder.RenameColumn(
                name: "FarmerID",
                table: "Farms",
                newName: "FarmerId");

            migrationBuilder.RenameColumn(
                name: "FarmID",
                table: "Farms",
                newName: "FarmId");

            migrationBuilder.RenameIndex(
                name: "IX_Farm_FarmerID",
                table: "Farms",
                newName: "IX_Farms_FarmerId");

            migrationBuilder.RenameColumn(
                name: "FarmerID",
                table: "CattleSaleRecords",
                newName: "FarmerId");

            migrationBuilder.RenameColumn(
                name: "CattleID",
                table: "CattleSaleRecords",
                newName: "CattleId");

            migrationBuilder.RenameColumn(
                name: "BuyerID",
                table: "CattleSaleRecords",
                newName: "BuyerId");

            migrationBuilder.RenameColumn(
                name: "SaleID",
                table: "CattleSaleRecords",
                newName: "SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_CattleSaleRecord_FarmerID",
                table: "CattleSaleRecords",
                newName: "IX_CattleSaleRecords_FarmerId");

            migrationBuilder.RenameIndex(
                name: "IX_CattleSaleRecord_CattleID",
                table: "CattleSaleRecords",
                newName: "IX_CattleSaleRecords_CattleId");

            migrationBuilder.RenameIndex(
                name: "IX_CattleSaleRecord_BuyerID",
                table: "CattleSaleRecords",
                newName: "IX_CattleSaleRecords_BuyerId");

            migrationBuilder.RenameColumn(
                name: "PhotoURL",
                table: "CattlePhotos",
                newName: "PhotoUrl");

            migrationBuilder.RenameColumn(
                name: "CattleID",
                table: "CattlePhotos",
                newName: "CattleId");

            migrationBuilder.RenameColumn(
                name: "PhotoID",
                table: "CattlePhotos",
                newName: "PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_CattlePhoto_CattleID",
                table: "CattlePhotos",
                newName: "IX_CattlePhotos_CattleId");

            migrationBuilder.RenameColumn(
                name: "CattleID",
                table: "CattleHealthRecords",
                newName: "CattleId");

            migrationBuilder.RenameColumn(
                name: "RecordID",
                table: "CattleHealthRecords",
                newName: "RecordId");

            migrationBuilder.RenameIndex(
                name: "IX_CattleHealthRecord_CattleID",
                table: "CattleHealthRecords",
                newName: "IX_CattleHealthRecords_CattleId");

            migrationBuilder.RenameColumn(
                name: "HerdID",
                table: "Cattles",
                newName: "HerdId");

            migrationBuilder.RenameColumn(
                name: "FarmerID",
                table: "Cattles",
                newName: "FarmerId");

            migrationBuilder.RenameColumn(
                name: "CattleID",
                table: "Cattles",
                newName: "CattleId");

            migrationBuilder.RenameIndex(
                name: "IX_Cattle_HerdID",
                table: "Cattles",
                newName: "IX_Cattles_HerdId");

            migrationBuilder.RenameIndex(
                name: "IX_Cattle_FarmerID",
                table: "Cattles",
                newName: "IX_Cattles_FarmerId");

            migrationBuilder.RenameColumn(
                name: "BPhoneNumber",
                table: "Buyers",
                newName: "BphoneNumber");

            migrationBuilder.RenameColumn(
                name: "BLastName",
                table: "Buyers",
                newName: "BlastName");

            migrationBuilder.RenameColumn(
                name: "BIDNumber",
                table: "Buyers",
                newName: "Bidnumber");

            migrationBuilder.RenameColumn(
                name: "BFirstName",
                table: "Buyers",
                newName: "BfirstName");

            migrationBuilder.RenameColumn(
                name: "BEmail",
                table: "Buyers",
                newName: "Bemail");

            migrationBuilder.RenameColumn(
                name: "BuyerID",
                table: "Buyers",
                newName: "BuyerId");

            migrationBuilder.AlterColumn<int>(
                name: "HerdId",
                table: "HerdComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "HerdComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "HerdComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "Herds",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "Herds",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HerdId",
                table: "Herds",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "Farmers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "Farms",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "Farms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "CattleSaleRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CattleId",
                table: "CattleSaleRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "CattleSaleRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "CattleSaleRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "CattlePhotos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CattlePhotos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CattleId",
                table: "CattlePhotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "CattlePhotos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "TreatmentType",
                table: "CattleHealthRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "CattleHealthRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "CattleId",
                table: "CattleHealthRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecordId",
                table: "CattleHealthRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "HerdId",
                table: "Cattles",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "Cattles",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CattleId",
                table: "Cattles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationName",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BphoneNumber",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "BlastName",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Bidnumber",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BfirstName",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Bemail",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Buyers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BConfirmPassword",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HerdComments",
                table: "HerdComments",
                column: "CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Herds",
                table: "Herds",
                column: "HerdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Farmers",
                table: "Farmers",
                column: "FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Farms",
                table: "Farms",
                column: "FarmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CattleSaleRecords",
                table: "CattleSaleRecords",
                column: "SaleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CattlePhotos",
                table: "CattlePhotos",
                column: "PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CattleHealthRecords",
                table: "CattleHealthRecords",
                column: "RecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cattles",
                table: "Cattles",
                column: "CattleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CattleHealthRecords_Cattles_CattleId",
                table: "CattleHealthRecords",
                column: "CattleId",
                principalTable: "Cattles",
                principalColumn: "CattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CattlePhotos_Cattles_CattleId",
                table: "CattlePhotos",
                column: "CattleId",
                principalTable: "Cattles",
                principalColumn: "CattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cattles_Farmers_FarmerId",
                table: "Cattles",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cattles_Herds_HerdId",
                table: "Cattles",
                column: "HerdId",
                principalTable: "Herds",
                principalColumn: "HerdId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CattleSaleRecords_Buyers_BuyerId",
                table: "CattleSaleRecords",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "BuyerId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CattleSaleRecords_Cattles_CattleId",
                table: "CattleSaleRecords",
                column: "CattleId",
                principalTable: "Cattles",
                principalColumn: "CattleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CattleSaleRecords_Farmers_FarmerId",
                table: "CattleSaleRecords",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HerdComments_Farmers_FarmerId",
                table: "HerdComments",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_HerdComments_Herds_HerdId",
                table: "HerdComments",
                column: "HerdId",
                principalTable: "Herds",
                principalColumn: "HerdId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Herds_Farmers_FarmerId",
                table: "Herds",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Herds_Farms_FarmId",
                table: "Herds",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CattleHealthRecords_Cattles_CattleId",
                table: "CattleHealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CattlePhotos_Cattles_CattleId",
                table: "CattlePhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cattles_Farmers_FarmerId",
                table: "Cattles");

            migrationBuilder.DropForeignKey(
                name: "FK_Cattles_Herds_HerdId",
                table: "Cattles");

            migrationBuilder.DropForeignKey(
                name: "FK_CattleSaleRecords_Buyers_BuyerId",
                table: "CattleSaleRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CattleSaleRecords_Cattles_CattleId",
                table: "CattleSaleRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CattleSaleRecords_Farmers_FarmerId",
                table: "CattleSaleRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_HerdComments_Farmers_FarmerId",
                table: "HerdComments");

            migrationBuilder.DropForeignKey(
                name: "FK_HerdComments_Herds_HerdId",
                table: "HerdComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Herds_Farmers_FarmerId",
                table: "Herds");

            migrationBuilder.DropForeignKey(
                name: "FK_Herds_Farms_FarmId",
                table: "Herds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Herds",
                table: "Herds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HerdComments",
                table: "HerdComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Farms",
                table: "Farms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Farmers",
                table: "Farmers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CattleSaleRecords",
                table: "CattleSaleRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cattles",
                table: "Cattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CattlePhotos",
                table: "CattlePhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CattleHealthRecords",
                table: "CattleHealthRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "BConfirmPassword",
                table: "Buyers");

            migrationBuilder.RenameTable(
                name: "Herds",
                newName: "Herd");

            migrationBuilder.RenameTable(
                name: "HerdComments",
                newName: "HerdComment");

            migrationBuilder.RenameTable(
                name: "Farms",
                newName: "Farm");

            migrationBuilder.RenameTable(
                name: "Farmers",
                newName: "Farmer");

            migrationBuilder.RenameTable(
                name: "CattleSaleRecords",
                newName: "CattleSaleRecord");

            migrationBuilder.RenameTable(
                name: "Cattles",
                newName: "Cattle");

            migrationBuilder.RenameTable(
                name: "CattlePhotos",
                newName: "CattlePhoto");

            migrationBuilder.RenameTable(
                name: "CattleHealthRecords",
                newName: "CattleHealthRecord");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "Buyer");

            migrationBuilder.RenameColumn(
                name: "FarmerId",
                table: "Herd",
                newName: "FarmerID");

            migrationBuilder.RenameColumn(
                name: "FarmId",
                table: "Herd",
                newName: "FarmID");

            migrationBuilder.RenameColumn(
                name: "HerdId",
                table: "Herd",
                newName: "HerdID");

            migrationBuilder.RenameIndex(
                name: "IX_Herds_FarmId",
                table: "Herd",
                newName: "IX_Herd_FarmID");

            migrationBuilder.RenameIndex(
                name: "IX_Herds_FarmerId",
                table: "Herd",
                newName: "IX_Herd_FarmerID");

            migrationBuilder.RenameColumn(
                name: "HerdId",
                table: "HerdComment",
                newName: "HerdID");

            migrationBuilder.RenameColumn(
                name: "FarmerId",
                table: "HerdComment",
                newName: "FarmerID");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "HerdComment",
                newName: "CommentID");

            migrationBuilder.RenameIndex(
                name: "IX_HerdComments_HerdId",
                table: "HerdComment",
                newName: "IX_HerdComment_HerdID");

            migrationBuilder.RenameIndex(
                name: "IX_HerdComments_FarmerId",
                table: "HerdComment",
                newName: "IX_HerdComment_FarmerID");

            migrationBuilder.RenameColumn(
                name: "FarmerId",
                table: "Farm",
                newName: "FarmerID");

            migrationBuilder.RenameColumn(
                name: "FarmId",
                table: "Farm",
                newName: "FarmID");

            migrationBuilder.RenameIndex(
                name: "IX_Farms_FarmerId",
                table: "Farm",
                newName: "IX_Farm_FarmerID");

            migrationBuilder.RenameColumn(
                name: "Idnumber",
                table: "Farmer",
                newName: "IDNumber");

            migrationBuilder.RenameColumn(
                name: "FarmerId",
                table: "Farmer",
                newName: "FarmerID");

            migrationBuilder.RenameIndex(
                name: "IX_Farmers_Idnumber",
                table: "Farmer",
                newName: "UQ__Farmer__564DB08AE2C54990");

            migrationBuilder.RenameIndex(
                name: "IX_Farmers_EmailAddress",
                table: "Farmer",
                newName: "UQ__Farmer__49A147408D2FB0FE");

            migrationBuilder.RenameColumn(
                name: "FarmerId",
                table: "CattleSaleRecord",
                newName: "FarmerID");

            migrationBuilder.RenameColumn(
                name: "CattleId",
                table: "CattleSaleRecord",
                newName: "CattleID");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "CattleSaleRecord",
                newName: "BuyerID");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "CattleSaleRecord",
                newName: "SaleID");

            migrationBuilder.RenameIndex(
                name: "IX_CattleSaleRecords_FarmerId",
                table: "CattleSaleRecord",
                newName: "IX_CattleSaleRecord_FarmerID");

            migrationBuilder.RenameIndex(
                name: "IX_CattleSaleRecords_CattleId",
                table: "CattleSaleRecord",
                newName: "IX_CattleSaleRecord_CattleID");

            migrationBuilder.RenameIndex(
                name: "IX_CattleSaleRecords_BuyerId",
                table: "CattleSaleRecord",
                newName: "IX_CattleSaleRecord_BuyerID");

            migrationBuilder.RenameColumn(
                name: "HerdId",
                table: "Cattle",
                newName: "HerdID");

            migrationBuilder.RenameColumn(
                name: "FarmerId",
                table: "Cattle",
                newName: "FarmerID");

            migrationBuilder.RenameColumn(
                name: "CattleId",
                table: "Cattle",
                newName: "CattleID");

            migrationBuilder.RenameIndex(
                name: "IX_Cattles_HerdId",
                table: "Cattle",
                newName: "IX_Cattle_HerdID");

            migrationBuilder.RenameIndex(
                name: "IX_Cattles_FarmerId",
                table: "Cattle",
                newName: "IX_Cattle_FarmerID");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "CattlePhoto",
                newName: "PhotoURL");

            migrationBuilder.RenameColumn(
                name: "CattleId",
                table: "CattlePhoto",
                newName: "CattleID");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "CattlePhoto",
                newName: "PhotoID");

            migrationBuilder.RenameIndex(
                name: "IX_CattlePhotos_CattleId",
                table: "CattlePhoto",
                newName: "IX_CattlePhoto_CattleID");

            migrationBuilder.RenameColumn(
                name: "CattleId",
                table: "CattleHealthRecord",
                newName: "CattleID");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "CattleHealthRecord",
                newName: "RecordID");

            migrationBuilder.RenameIndex(
                name: "IX_CattleHealthRecords_CattleId",
                table: "CattleHealthRecord",
                newName: "IX_CattleHealthRecord_CattleID");

            migrationBuilder.RenameColumn(
                name: "BphoneNumber",
                table: "Buyer",
                newName: "BPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "BlastName",
                table: "Buyer",
                newName: "BLastName");

            migrationBuilder.RenameColumn(
                name: "Bidnumber",
                table: "Buyer",
                newName: "BIDNumber");

            migrationBuilder.RenameColumn(
                name: "BfirstName",
                table: "Buyer",
                newName: "BFirstName");

            migrationBuilder.RenameColumn(
                name: "Bemail",
                table: "Buyer",
                newName: "BEmail");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Buyer",
                newName: "BuyerID");

            migrationBuilder.AlterColumn<string>(
                name: "FarmerID",
                table: "Herd",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FarmID",
                table: "Herd",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HerdID",
                table: "Herd",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "HerdID",
                table: "HerdComment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FarmerID",
                table: "HerdComment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentID",
                table: "HerdComment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FarmerID",
                table: "Farm",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FarmID",
                table: "Farm",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FarmerID",
                table: "Farmer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FarmerID",
                table: "CattleSaleRecord",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CattleID",
                table: "CattleSaleRecord",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerID",
                table: "CattleSaleRecord",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SaleID",
                table: "CattleSaleRecord",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "HerdID",
                table: "Cattle",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FarmerID",
                table: "Cattle",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CattleID",
                table: "Cattle",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoURL",
                table: "CattlePhoto",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CattlePhoto",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CattleID",
                table: "CattlePhoto",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoID",
                table: "CattlePhoto",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "TreatmentType",
                table: "CattleHealthRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "CattleHealthRecord",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CattleID",
                table: "CattleHealthRecord",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecordID",
                table: "CattleHealthRecord",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationName",
                table: "Buyer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BPhoneNumber",
                table: "Buyer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BLastName",
                table: "Buyer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BIDNumber",
                table: "Buyer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BFirstName",
                table: "Buyer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BEmail",
                table: "Buyer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerID",
                table: "Buyer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Herd__0889874A8A2B7728",
                table: "Herd",
                column: "HerdID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__HerdComm__C3B4DFAA66060F54",
                table: "HerdComment",
                column: "CommentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Farm__ED7BBA99F98F561A",
                table: "Farm",
                column: "FarmID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Farmer__731B88E8CB2BC6CA",
                table: "Farmer",
                column: "FarmerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CattleSa__1EE3C41F136A9DDC",
                table: "CattleSaleRecord",
                column: "SaleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Cattle__E375C63CBAD731FD",
                table: "Cattle",
                column: "CattleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CattlePh__21B7B5826EA21737",
                table: "CattlePhoto",
                column: "PhotoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CattleHe__FBDF78C921E20F58",
                table: "CattleHealthRecord",
                column: "RecordID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Buyer__4B81C1CA078A2677",
                table: "Buyer",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Buyer__218A515C8481D745",
                table: "Buyer",
                column: "BIDNumber",
                unique: true,
                filter: "[BIDNumber] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK__Cattle__FarmerID__44FF419A",
                table: "Cattle",
                column: "FarmerID",
                principalTable: "Farmer",
                principalColumn: "FarmerID");

            migrationBuilder.AddForeignKey(
                name: "FK__Cattle__HerdID__440B1D61",
                table: "Cattle",
                column: "HerdID",
                principalTable: "Herd",
                principalColumn: "HerdID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__CattleHea__Cattl__4AB81AF0",
                table: "CattleHealthRecord",
                column: "CattleID",
                principalTable: "Cattle",
                principalColumn: "CattleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__CattlePho__Cattl__47DBAE45",
                table: "CattlePhoto",
                column: "CattleID",
                principalTable: "Cattle",
                principalColumn: "CattleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__CattleSal__Buyer__52593CB8",
                table: "CattleSaleRecord",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "BuyerID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__CattleSal__Cattl__5070F446",
                table: "CattleSaleRecord",
                column: "CattleID",
                principalTable: "Cattle",
                principalColumn: "CattleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__CattleSal__Farme__5165187F",
                table: "CattleSaleRecord",
                column: "FarmerID",
                principalTable: "Farmer",
                principalColumn: "FarmerID");

            migrationBuilder.AddForeignKey(
                name: "FK__Farm__FarmerID__3B75D760",
                table: "Farm",
                column: "FarmerID",
                principalTable: "Farmer",
                principalColumn: "FarmerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Herd__FarmID__3E52440B",
                table: "Herd",
                column: "FarmID",
                principalTable: "Farm",
                principalColumn: "FarmID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Herd__FarmerID__3F466844",
                table: "Herd",
                column: "FarmerID",
                principalTable: "Farmer",
                principalColumn: "FarmerID");

            migrationBuilder.AddForeignKey(
                name: "FK__HerdComme__Farme__5629CD9C",
                table: "HerdComment",
                column: "FarmerID",
                principalTable: "Farmer",
                principalColumn: "FarmerID");

            migrationBuilder.AddForeignKey(
                name: "FK__HerdComme__HerdI__5535A963",
                table: "HerdComment",
                column: "HerdID",
                principalTable: "Herd",
                principalColumn: "HerdID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
