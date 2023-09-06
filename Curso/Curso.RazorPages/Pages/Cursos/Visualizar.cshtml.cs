using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.RazorPages.Models;
using Curso.RazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cursos.RazorPages.Pages.Cursos
{
    public class VisualizarModel : PageModel
    {
        private readonly AppDbContext _context;
        public CursoModel CursoDetails { get; set; } = new CursoModel();
        public List<AlunoModel> AlunosMatriculados { get; set; } = new List<AlunoModel>();

        public VisualizarModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busque os IDs dos alunos matriculados no curso a partir da tabela AlunoCurso
            var alunoIdsMatriculados = await _context.AlunoCursos
                .Where(ac => ac.CursoId == id)
                .Select(ac => ac.AlunoId)
                .ToListAsync();

            // Busque os detalhes do curso incluindo os alunos matriculados
            CursoDetails = await _context.Cursos
                .Include(c => c.Alunos)
                .Where(c => c.CursoId == id)
                .FirstOrDefaultAsync();

            if (CursoDetails == null)
            {
                return NotFound();
            }

            // Carregue todos os alunos matriculados no curso com base nos IDs obtidos
            AlunosMatriculados = await _context.Alunos
                .Where(a => alunoIdsMatriculados.Contains(a.AlunoId))
                .ToListAsync();

            return Page();
        }
    }
}
