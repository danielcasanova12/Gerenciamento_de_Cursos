using System.Threading.Tasks;
using Curso.RazorPages.Models;
using Curso.RazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cursos.RazorPages.Pages.Cursos // Certifique-se de que o namespace esteja correto
{
    public class VisualizarModel : PageModel
    {
        private readonly AppDbContext _context;
        public CursoModel CursoDetails { get; set; } = new CursoModel(); // Use a classe Curso para representar os cursos

        public VisualizarModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos.FirstOrDefaultAsync(c => c.CursoId == id);
            if (cursoModel == null)
            {
                return NotFound();
            }

            CursoDetails = cursoModel;

            return Page();
        }
    }
}
