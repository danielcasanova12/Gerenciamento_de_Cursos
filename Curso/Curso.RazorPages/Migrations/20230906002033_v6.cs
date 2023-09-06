using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoCursos",
                columns: table => new
                {
                    AlunoCursoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: true),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCursos", x => x.AlunoCursoId);
                    table.ForeignKey(
                        name: "FK_AlunoCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId");
                    table.ForeignKey(
                        name: "FK_AlunoCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCursos_AlunoId",
                table: "AlunoCursos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCursos_CursoId",
                table: "AlunoCursos",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoCursos");
        }
    }
}
