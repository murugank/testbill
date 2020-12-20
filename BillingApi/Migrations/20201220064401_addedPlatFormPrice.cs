using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingApi.Migrations
{
    public partial class addedPlatFormPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlatformPrices",
                columns: table => new
                {
                    PlatformPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GstPlatformRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastModifiedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformPrices", x => x.PlatformPriceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformPrices");
        }
    }
}
