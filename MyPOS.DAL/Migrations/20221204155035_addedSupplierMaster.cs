using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPOS.DAL.Migrations
{
    public partial class addedSupplierMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "ProductMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierMasterSupplierId",
                table: "ProductMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SupplierMaster",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierMaster", x => x.SupplierId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaster_SupplierMasterSupplierId",
                table: "ProductMaster",
                column: "SupplierMasterSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMaster_SupplierMaster_SupplierMasterSupplierId",
                table: "ProductMaster",
                column: "SupplierMasterSupplierId",
                principalTable: "SupplierMaster",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaster_SupplierMaster_SupplierMasterSupplierId",
                table: "ProductMaster");

            migrationBuilder.DropTable(
                name: "SupplierMaster");

            migrationBuilder.DropIndex(
                name: "IX_ProductMaster_SupplierMasterSupplierId",
                table: "ProductMaster");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ProductMaster");

            migrationBuilder.DropColumn(
                name: "SupplierMasterSupplierId",
                table: "ProductMaster");
        }
    }
}
