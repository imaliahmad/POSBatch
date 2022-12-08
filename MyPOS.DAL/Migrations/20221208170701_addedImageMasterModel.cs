using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPOS.DAL.Migrations
{
    public partial class addedImageMasterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaster_SupplierMaster_SupplierMasterSupplierId",
                table: "ProductMaster");

            migrationBuilder.DropIndex(
                name: "IX_ProductMaster_SupplierMasterSupplierId",
                table: "ProductMaster");

            migrationBuilder.DropColumn(
                name: "SupplierMasterSupplierId",
                table: "ProductMaster");

            migrationBuilder.AddColumn<long>(
                name: "ImageMasterId",
                table: "SupplierMaster",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ImageMaster",
                columns: table => new
                {
                    ImageMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageMaster", x => x.ImageMasterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierMaster_ImageMasterId",
                table: "SupplierMaster",
                column: "ImageMasterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaster_SupplierId",
                table: "ProductMaster",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMaster_SupplierMaster_SupplierId",
                table: "ProductMaster",
                column: "SupplierId",
                principalTable: "SupplierMaster",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierMaster_ImageMaster_ImageMasterId",
                table: "SupplierMaster",
                column: "ImageMasterId",
                principalTable: "ImageMaster",
                principalColumn: "ImageMasterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaster_SupplierMaster_SupplierId",
                table: "ProductMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierMaster_ImageMaster_ImageMasterId",
                table: "SupplierMaster");

            migrationBuilder.DropTable(
                name: "ImageMaster");

            migrationBuilder.DropIndex(
                name: "IX_SupplierMaster_ImageMasterId",
                table: "SupplierMaster");

            migrationBuilder.DropIndex(
                name: "IX_ProductMaster_SupplierId",
                table: "ProductMaster");

            migrationBuilder.DropColumn(
                name: "ImageMasterId",
                table: "SupplierMaster");

            migrationBuilder.AddColumn<int>(
                name: "SupplierMasterSupplierId",
                table: "ProductMaster",
                type: "int",
                nullable: true);

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
    }
}
