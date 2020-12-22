using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingApi.Migrations
{
    public partial class AddedSubscriptionheadanddetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubscriptionHeads",
                columns: table => new
                {
                    SubscriptionHeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalAppAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAppGstAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlatformCount = table.Column<int>(type: "int", nullable: false),
                    TotalPlatformAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPlatformGstAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastModifiedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionHeads", x => x.SubscriptionHeadId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionDetails",
                columns: table => new
                {
                    SubscriptionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionHeadId = table.Column<int>(type: "int", nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    UserCount = table.Column<int>(type: "int", nullable: false),
                    AppRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppGst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedAppAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedGSTAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastModifiedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionDetails", x => x.SubscriptionDetailId);
                    table.ForeignKey(
                        name: "FK_SubscriptionDetails_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionDetails_SubscriptionHeads_SubscriptionHeadId",
                        column: x => x.SubscriptionHeadId,
                        principalTable: "SubscriptionHeads",
                        principalColumn: "SubscriptionHeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionDetails_AppId",
                table: "SubscriptionDetails",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionDetails_SubscriptionHeadId",
                table: "SubscriptionDetails",
                column: "SubscriptionHeadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionDetails");

            migrationBuilder.DropTable(
                name: "SubscriptionHeads");
        }
    }
}
