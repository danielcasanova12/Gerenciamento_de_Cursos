using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAlunoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeAluno = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DataInscricao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAlunoId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCursoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCurso = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCursoId);
                });

            migrationBuilder.CreateTable(
                name: "AlunoModelCursoModel",
                columns: table => new
                {
                    AlunosIdAlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursosIdCursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoModelCursoModel", x => new { x.AlunosIdAlunoId, x.CursosIdCursoId });
                    table.ForeignKey(
                        name: "FK_AlunoModelCursoModel_Alunos_AlunosIdAlunoId",
                        column: x => x.AlunosIdAlunoId,
                        principalTable: "Alunos",
                        principalColumn: "IdAlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoModelCursoModel_Cursos_CursosIdCursoId",
                        column: x => x.CursosIdCursoId,
                        principalTable: "Cursos",
                        principalColumn: "IdCursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoModelCursoModel_CursosIdCursoId",
                table: "AlunoModelCursoModel",
                column: "CursosIdCursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoModelCursoModel");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
