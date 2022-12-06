using Microsoft.EntityFrameworkCore.Migrations;

namespace COVID_19_App.Migrations
{
    public partial class AddedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Cases = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Global",
                columns: table => new
                {
                    NewConfirmed = table.Column<int>(type: "int", nullable: false),
                    TotalConfirmed = table.Column<int>(type: "int", nullable: false),
                    NewDeaths = table.Column<int>(type: "int", nullable: false),
                    TotalDeaths = table.Column<int>(type: "int", nullable: false),
                    NewRecovered = table.Column<int>(type: "int", nullable: false),
                    TotalRecovered = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Premium",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Summaries",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summaries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TotalStatistics",
                columns: table => new
                {
                    TotalConfirmed = table.Column<int>(type: "int", nullable: false),
                    TotalDeaths = table.Column<int>(type: "int", nullable: false),
                    TotalRecovered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CountrySummaries",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewConfirmed = table.Column<int>(type: "int", nullable: false),
                    TotalConfirmed = table.Column<int>(type: "int", nullable: false),
                    NewDeaths = table.Column<int>(type: "int", nullable: false),
                    TotalDeaths = table.Column<int>(type: "int", nullable: false),
                    NewRecovered = table.Column<int>(type: "int", nullable: false),
                    TotalRecovered = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PremiumID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WholeSummaryID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountrySummaries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CountrySummaries_Premium_PremiumID",
                        column: x => x.PremiumID,
                        principalTable: "Premium",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountrySummaries_Summaries_WholeSummaryID",
                        column: x => x.WholeSummaryID,
                        principalTable: "Summaries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountrySummaries_PremiumID",
                table: "CountrySummaries",
                column: "PremiumID");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySummaries_WholeSummaryID",
                table: "CountrySummaries",
                column: "WholeSummaryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CountrySummaries");

            migrationBuilder.DropTable(
                name: "Global");

            migrationBuilder.DropTable(
                name: "TotalStatistics");

            migrationBuilder.DropTable(
                name: "Premium");

            migrationBuilder.DropTable(
                name: "Summaries");
        }
    }
}
