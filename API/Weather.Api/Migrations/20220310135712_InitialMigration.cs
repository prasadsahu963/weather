using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitMeasures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForecastDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<int>(type: "int", nullable: false),
                    IconPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CloudCover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WindSpeedUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForecastDetails_UnitMeasures_WindSpeedUnitId",
                        column: x => x.WindSpeedUnitId,
                        principalTable: "UnitMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatures_UnitMeasures_UnitMeasureId",
                        column: x => x.UnitMeasureId,
                        principalTable: "UnitMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationKey = table.Column<int>(type: "int", nullable: false),
                    ForecastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SunRiseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SunSetTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealFeelTemperatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_ForecastDetails_DayId",
                        column: x => x.DayId,
                        principalTable: "ForecastDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_ForecastDetails_NightId",
                        column: x => x.NightId,
                        principalTable: "ForecastDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_Temperatures_RealFeelTemperatureId",
                        column: x => x.RealFeelTemperatureId,
                        principalTable: "Temperatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_Temperatures_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UnitMeasures",
                columns: new[] { "Id", "Unit", "UnitType" },
                values: new object[,]
                {
                    { new Guid("61b73b2d-9700-4218-8060-709acd6aa7b6"), "ft", 0 },
                    { new Guid("daafe775-7fc1-4130-aa55-7bf0298d19a3"), "%", 20 },
                    { new Guid("018668fa-a4af-4fdd-8a3f-afb472c86892"), "K", 19 },
                    { new Guid("87fb5cba-743d-41a1-b4a4-38a9405e607d"), "F", 18 },
                    { new Guid("58f99efa-1f42-4ece-8b7a-0fdfdff4bbd9"), "C", 17 },
                    { new Guid("47aa9f41-f568-47be-af67-50ecd47fe4b8"), "psi", 16 },
                    { new Guid("a4811808-8095-4f20-b668-961ab84236ac"), "mmHg", 15 },
                    { new Guid("1a287533-4913-4290-a45a-fe441104373e"), "mbar", 14 },
                    { new Guid("50910943-cd41-4952-ab1e-fa048722b3ae"), "kPa", 13 },
                    { new Guid("66c5ac1e-3e37-42e1-93d9-a27a5d1acbda"), "Hg", 12 },
                    { new Guid("dcde2621-590c-4538-b14a-d3a7809fbf35"), "f", 21 },
                    { new Guid("d91a7b90-7d6e-4f22-a193-ab1d2cba0e68"), "hPa", 11 },
                    { new Guid("1bac4b2f-5cf8-4372-a2aa-030226bb6ddb"), "mi/h", 9 },
                    { new Guid("de431486-6bf5-4165-a8cb-70536fb3ada5"), "kt", 8 },
                    { new Guid("89c6af97-4da4-442e-b739-a75caa7c3b37"), "km/h", 7 },
                    { new Guid("7a2ef28d-2451-4a9f-9fc7-78e381c9b8fc"), "km", 6 },
                    { new Guid("b4354f46-4c7f-47d1-ad64-a6b0314b3f63"), "m", 5 },
                    { new Guid("1639442b-ab88-4359-88e4-f6b4de83db1b"), "cm", 4 },
                    { new Guid("9cdcaf5d-5006-4093-b377-cca17fdc5bb1"), "mm", 3 },
                    { new Guid("febbb09a-f389-470f-9648-06490333001a"), "mi", 2 },
                    { new Guid("bc44ffb1-44b4-42a1-a5a7-064342c78e02"), "in", 1 },
                    { new Guid("4a8a8c16-83ef-46e1-bdef-6aae89f18a17"), "m/s", 10 },
                    { new Guid("daa7eec5-9af2-465d-8232-faffe5c8f9cc"), "int", 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForecastDetails_WindSpeedUnitId",
                table: "ForecastDetails",
                column: "WindSpeedUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_UnitMeasureId",
                table: "Temperatures",
                column: "UnitMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_DayId",
                table: "WeatherForecasts",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_NightId",
                table: "WeatherForecasts",
                column: "NightId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_RealFeelTemperatureId",
                table: "WeatherForecasts",
                column: "RealFeelTemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_TemperatureId",
                table: "WeatherForecasts",
                column: "TemperatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "ForecastDetails");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "UnitMeasures");
        }
    }
}
