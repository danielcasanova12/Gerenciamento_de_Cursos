using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdicionarAlunoCursoViewModelId",
                table: "Cursos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdicionarAlunoCursoViewModelId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdicionarAlunoCursoViewModels",
                columns: table => new
                {
                    AdicionarAlunoCursoViewModelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: true),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdicionarAlunoCursoViewModels", x => x.AdicionarAlunoCursoViewModelId);
                    table.ForeignKey(
                        name: "FK_AdicionarAlunoCursoViewModels_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AdicionarAlunoCursoViewModelId",
                table: "Cursos",
                column: "AdicionarAlunoCursoViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_AdicionarAlunoCursoViewModelId",
                table: "Alunos",
                column: "AdicionarAlunoCursoViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AdicionarAlunoCursoViewModels_CursoId",
                table: "AdicionarAlunoCursoViewModels",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_AdicionarAlunoCursoViewModels_AdicionarAlunoCursoViewModelId",
                table: "Alunos",
                column: "AdicionarAlunoCursoViewModelId",
                principalTable: "AdicionarAlunoCursoViewModels",
                principalColumn: "AdicionarAlunoCursoViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_AdicionarAlunoCursoViewModels_AdicionarAlunoCursoViewModelId",
                table: "Cursos",
                column: "AdicionarAlunoCursoViewModelId",
                principalTable: "AdicionarAlunoCursoViewModels",
                principalColumn: "AdicionarAlunoCursoViewModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_AdicionarAlunoCursoViewModels_AdicionarAlunoCursoViewModelId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_AdicionarAlunoCursoViewModels_AdicionarAlunoCursoViewModelId",
                table: "Cursos");

            migrationBuilder.DropTable(
                name: "AdicionarAlunoCursoViewModels");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_AdicionarAlunoCursoViewModelId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_AdicionarAlunoCursoViewModelId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "AdicionarAlunoCursoViewModelId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "AdicionarAlunoCursoViewModelId",
                table: "Alunos");
        }
    }
}
