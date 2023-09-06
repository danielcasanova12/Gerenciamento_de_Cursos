using System.Linq;
using Curso.RazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Feedback.RazorPages.Pages
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public int TotalCursos { get; set; }
        public int TotalAlunos { get; set; }
        public string CursoComMaisInscricoes { get; set; }

        public IActionResult OnGet()
        {
            TotalCursos = _context.Cursos.Count();
            TotalAlunos = _context.Alunos.Count();

            var cursoMaisInscricoes = _context.Cursos
                .Include(c => c.Alunos)
                .OrderByDescending(c => c.Alunos.Count)
                .FirstOrDefault();

            if (cursoMaisInscricoes != null)
            {
                CursoComMaisInscricoes = cursoMaisInscricoes.NomeCurso;
            }
            else
            {
                CursoComMaisInscricoes = "Nenhum curso com inscrições";
            }

            return Page();
        }
    }
}
