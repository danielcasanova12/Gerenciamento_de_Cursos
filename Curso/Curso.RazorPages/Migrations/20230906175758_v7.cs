using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlunoJaInscrito",
                table: "AdicionarAlunoCursoViewModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlunoJaInscrito",
                table: "AdicionarAlunoCursoViewModels");
        }
    }
}
