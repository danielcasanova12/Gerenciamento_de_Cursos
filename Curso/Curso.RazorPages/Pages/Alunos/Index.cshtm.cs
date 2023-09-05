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

            if (!string.IsNullOrEmpty(NomeFiltro))
            {
                alunosQuery = alunosQuery.Where(a => a.NomeAluno!.Contains(NomeFiltro));
            }

            if (Ordenacao == "asc")
            {
                alunosQuery = alunosQuery.OrderBy(a => a.DataInscricao);
            }
            else if (Ordenacao == "desc")
            {
                alunosQuery = alunosQuery.OrderByDescending(a => a.DataInscricao);
            }

            AlunosList = await alunosQuery.ToListAsync();
        }
    }
}
