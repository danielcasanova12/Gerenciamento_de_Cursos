using Curso.RazorPages.Models;
using Curso.RazorPages.Data; // Certifique-se de que o namespace esteja correto
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cursos.RazorPages.Pages.Cursos // Defina o namespace correto para a página de criação de cursos
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        
        [BindProperty]
        public CursoModel CursoDetails { get; set; } = new CursoModel(); // Use a classe Curso para representar os detalhes do curso

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Cursos.Add(CursoDetails); // Use DbSet<Cursos> para adicionar o curso ao contexto
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Index"); // Redirecione para a página de listagem de cursos
            }
            catch (Exception)
            {
                return Page();
            }
        }
    }
}
