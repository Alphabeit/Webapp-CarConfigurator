using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PS = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBodys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBodys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wheels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wheels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleBodyId = table.Column<int>(type: "int", nullable: false),
                    VehicleColorId = table.Column<int>(type: "int", nullable: false),
                    WheelId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_VehicleBodys_VehicleBodyId",
                        column: x => x.VehicleBodyId,
                        principalTable: "VehicleBodys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_VehicleColors_VehicleColorId",
                        column: x => x.VehicleColorId,
                        principalTable: "VehicleColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Wheels_WheelId",
                        column: x => x.WheelId,
                        principalTable: "Wheels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EngineId",
                table: "Orders",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleBodyId",
                table: "Orders",
                column: "VehicleBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleColorId",
                table: "Orders",
                column: "VehicleColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WheelId",
                table: "Orders",
                column: "WheelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "VehicleBodys");

            migrationBuilder.DropTable(
                name: "VehicleColors");

            migrationBuilder.DropTable(
                name: "Wheels");
        }
    }
}
