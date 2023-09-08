using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Curso.RazorPages.Data;
using Curso.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursos.RazorPages.Pages.Alunos
{
    public class IndexAlunos : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty(SupportsGet = true)]
        public string NomeFiltro { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordenacao { get; set; }

        public List<AlunoModel> AlunosList { get; set; } = new List<AlunoModel>();

        public IndexAlunos(AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            var alunosQuery = _context.Alunos.AsQueryable();

            
            AlunosList = await alunosQuery.ToListAsync();
        }
    }
}
