using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PadelClub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canchas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Número = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Techada = table.Column<bool>(type: "bit", nullable: false),
                    PrecioPorTurno = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Habilitada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canchas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Canchas",
                columns: new[] { "Id", "Habilitada", "Número", "PrecioPorTurno", "Techada", "Tipo" },
                values: new object[,]
                {
                    { 1, true, 1, 18000m, true, "Cristal" },
                    { 2, true, 2, 15000m, false, "Cristal" },
                    { 3, true, 3, 16000m, true, "Muro" },
                    { 4, true, 4, 14000m, false, "Muro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_Número",
                table: "Canchas",
                column: "Número",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canchas");
        }
    }
}
