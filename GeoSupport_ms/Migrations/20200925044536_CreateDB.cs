using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSupport_ms.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id_color = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<double>(maxLength: 20, nullable: false),
                    HexCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id_color);
                });

            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    Id_continent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.Id_continent);
                });

            migrationBuilder.CreateTable(
                name: "Flag",
                columns: table => new
                {
                    Id_flag = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlagImage = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flag", x => x.Id_flag);
                });

            migrationBuilder.CreateTable(
                name: "Color_Flag",
                columns: table => new
                {
                    Id_flag = table.Column<int>(nullable: false),
                    Id_color = table.Column<int>(nullable: false),
                    order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color_Flag", x => new { x.Id_color, x.Id_flag });
                    table.ForeignKey(
                        name: "FK_Color_Flag_Color_Id_color",
                        column: x => x.Id_color,
                        principalTable: "Color",
                        principalColumn: "Id_color",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Color_Flag_Flag_Id_flag",
                        column: x => x.Id_flag,
                        principalTable: "Flag",
                        principalColumn: "Id_flag",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id_country = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContinentId_continent = table.Column<int>(nullable: false),
                    FlagId_flag = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Capital = table.Column<string>(maxLength: 20, nullable: false),
                    MapImage = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id_country);
                    table.ForeignKey(
                        name: "FK_Country_Continent_ContinentId_continent",
                        column: x => x.ContinentId_continent,
                        principalTable: "Continent",
                        principalColumn: "Id_continent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Country_Flag_FlagId_flag",
                        column: x => x.FlagId_flag,
                        principalTable: "Flag",
                        principalColumn: "Id_flag",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Place_1",
                columns: table => new
                {
                    Id_place = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId_country = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    PlaceImage = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place_1", x => x.Id_place);
                    table.ForeignKey(
                        name: "FK_Place_1_Country_CountryId_country",
                        column: x => x.CountryId_country,
                        principalTable: "Country",
                        principalColumn: "Id_country",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Color_Flag_Id_flag",
                table: "Color_Flag",
                column: "Id_flag");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ContinentId_continent",
                table: "Country",
                column: "ContinentId_continent");

            migrationBuilder.CreateIndex(
                name: "IX_Country_FlagId_flag",
                table: "Country",
                column: "FlagId_flag");

            migrationBuilder.CreateIndex(
                name: "IX_Place_1_CountryId_country",
                table: "Place_1",
                column: "CountryId_country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Color_Flag");

            migrationBuilder.DropTable(
                name: "Place_1");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Continent");

            migrationBuilder.DropTable(
                name: "Flag");
        }
    }
}
