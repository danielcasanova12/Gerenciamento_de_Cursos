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

    if (CursoDetails.DataTermino <= CursoDetails.DataInicio)
    {
        ModelState.AddModelError("CursoDetails.DataTermino", "A data de término deve ser posterior à data de início.");
        return Page();
    }

    try
    {
        _context.Cursos.Add(CursoDetails);
        await _context.SaveChangesAsync();
        return RedirectToPage("/Cursos/Index");
    }
    catch (Exception)
    {
        return Page();
    }
}

    }
}
