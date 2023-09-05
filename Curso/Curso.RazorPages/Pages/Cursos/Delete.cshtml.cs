using System;
using System.Threading.Tasks;
using Curso.RazorPages.Data; // Certifique-se de que o namespace esteja correto
using Curso.RazorPages.Models; // Certifique-se de que o namespace esteja correto
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cursos.RazorPages.Pages.Cursos // Certifique-se de que o namespace esteja correto
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public CursoModel CursoToDelete { get; set; } = new CursoModel(); // Use a classe Curso para representar os cursos

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var cursoToDelete = await _context.Cursos.FindAsync(id);
            if (cursoToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _context.Cursos.Remove(cursoToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            catch (Exception)
            {
                return Page();
            }
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

            CursoToDelete = cursoModel;

            return Page();
        }
    }
}
