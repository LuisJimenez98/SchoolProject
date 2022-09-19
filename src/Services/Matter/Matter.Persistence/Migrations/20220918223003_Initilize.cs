using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matter.Persistence.Migrations
{
    public partial class Initilize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Matter");

            migrationBuilder.CreateTable(
                name: "Materias",
                schema: "Matter",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColegioId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    NumeroEstudiantes = table.Column<int>(type: "int", nullable: false),
                    DocenteAsignado = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Curso = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Paralelo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Nombre",
                schema: "Matter",
                table: "Materias",
                column: "Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materias",
                schema: "Matter");
        }
    }
}
