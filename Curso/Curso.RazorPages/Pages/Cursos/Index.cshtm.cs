using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Curso.RazorPages.Data;
using Curso.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursos.RazorPages.Pages.Cursos
{
    public class  IndexCursos  : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty(SupportsGet = true)]
        public string NomeFiltro { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordenacao { get; set; }

        public List<CursoModel> CursosList { get; set; } = new List<CursoModel>();

        public  IndexCursos (AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            var cursosQuery = _context.Cursos.AsQueryable();

            if (!string.IsNullOrEmpty(NomeFiltro))
            {
                cursosQuery = cursosQuery.Where(c => c.NomeCurso!.Contains(NomeFiltro));
            }

            if (Ordenacao == "asc")
            {
                cursosQuery = cursosQuery.OrderBy(c => c.DataInicio);
            }
            else if (Ordenacao == "desc")
            {
                cursosQuery = cursosQuery.OrderByDescending(c => c.DataInicio);
            }

            CursosList = await cursosQuery.ToListAsync();
        }
    }
}
