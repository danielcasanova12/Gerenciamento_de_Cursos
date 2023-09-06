using System.Threading.Tasks;
using Curso.RazorPages.Models;
using Curso.RazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            CursoDetails = await _context.Cursos
                .Include(c => c.Alunos)
                .FirstOrDefaultAsync(c => c.CursoId == id);

            if (CursoDetails == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                     AlunosMatriculados = CursoDetails.Alunos.ToList();
                   foreach (var item in AlunosMatriculados)
                   {
                    System.Console.WriteLine(item);
                   }  
            }
            // Carregue todos os alunos matriculados no curso
            AlunosMatriculados = CursoDetails.Alunos.ToList();

            return Page();
        }
    }
}
