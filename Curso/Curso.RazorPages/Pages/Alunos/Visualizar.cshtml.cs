using System.Threading.Tasks;
using Curso.RazorPages.Models;
using Curso.RazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cursos.RazorPages.Pages.Alunos
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        public AlunoModel AlunoDetails { get; set; } = new AlunoModel();

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.Alunos.FirstOrDefaultAsync(a => a.AlunoId == id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            AlunoDetails = alunoModel;

            return Page();
        }
    }
}
