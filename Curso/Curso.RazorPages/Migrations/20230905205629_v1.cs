using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoModelCursoModel_Alunos_AlunosIdAlunoId",
                table: "AlunoModelCursoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoModelCursoModel_Cursos_CursosIdCursoId",
                table: "AlunoModelCursoModel");

            migrationBuilder.RenameColumn(
                name: "IdCursoId",
                table: "Cursos",
                newName: "CursoId");

            migrationBuilder.RenameColumn(
                name: "IdAlunoId",
                table: "Alunos",
                newName: "AlunoId");

            migrationBuilder.RenameColumn(
                name: "CursosIdCursoId",
                table: "AlunoModelCursoModel",
                newName: "CursosCursoId");

            migrationBuilder.RenameColumn(
                name: "AlunosIdAlunoId",
                table: "AlunoModelCursoModel",
                newName: "AlunosAlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoModelCursoModel_CursosIdCursoId",
                table: "AlunoModelCursoModel",
                newName: "IX_AlunoModelCursoModel_CursosCursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoModelCursoModel_Alunos_AlunosAlunoId",
                table: "AlunoModelCursoModel",
                column: "AlunosAlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoModelCursoModel_Cursos_CursosCursoId",
                table: "AlunoModelCursoModel",
                column: "CursosCursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoModelCursoModel_Alunos_AlunosAlunoId",
                table: "AlunoModelCursoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoModelCursoModel_Cursos_CursosCursoId",
                table: "AlunoModelCursoModel");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Cursos",
                newName: "IdCursoId");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Alunos",
                newName: "IdAlunoId");

            migrationBuilder.RenameColumn(
                name: "CursosCursoId",
                table: "AlunoModelCursoModel",
                newName: "CursosIdCursoId");

            migrationBuilder.RenameColumn(
                name: "AlunosAlunoId",
                table: "AlunoModelCursoModel",
                newName: "AlunosIdAlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoModelCursoModel_CursosCursoId",
                table: "AlunoModelCursoModel",
                newName: "IX_AlunoModelCursoModel_CursosIdCursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoModelCursoModel_Alunos_AlunosIdAlunoId",
                table: "AlunoModelCursoModel",
                column: "AlunosIdAlunoId",
                principalTable: "Alunos",
                principalColumn: "IdAlunoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoModelCursoModel_Cursos_CursosIdCursoId",
                table: "AlunoModelCursoModel",
                column: "CursosIdCursoId",
                principalTable: "Cursos",
                principalColumn: "IdCursoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
