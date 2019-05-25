using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Goods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_StoreId",
                table: "Goods",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Store_StoreId",
                table: "Goods",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Store_StoreId",
                table: "Goods");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Goods_StoreId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Goods");
        }
    }
}
