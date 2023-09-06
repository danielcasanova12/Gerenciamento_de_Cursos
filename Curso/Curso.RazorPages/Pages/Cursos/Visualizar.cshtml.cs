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

            return Page();
        }
    }
}
