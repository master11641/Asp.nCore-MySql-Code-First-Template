using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    HouseType = table.Column<int>(nullable: false),
                    EarthSituation = table.Column<string>(nullable: true),
                    DocumentSituation = table.Column<string>(nullable: true),
                    HouseSituation = table.Column<int>(nullable: false),
                    HeadName = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    BuyDate = table.Column<DateTime>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    ReciveType = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    GiftedFrom = table.Column<string>(nullable: true),
                    BuyerName = table.Column<string>(nullable: true),
                    RegisterNumber = table.Column<int>(nullable: true),
                    HouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Goods_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Goods_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_HouseId",
                table: "Goods",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_StoreId",
                table: "Goods",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
