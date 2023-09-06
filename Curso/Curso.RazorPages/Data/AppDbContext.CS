using Curso.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso.RazorPages.Data
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<AdicionarAlunoCursoViewModel> AdicionarAlunoCursoViewModels { get; set; }
        public DbSet<AlunoCurso> AlunoCursos { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Tds.db;Cache=Shared");
        }
    }
}