using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.RazorPages.Data;
using Curso.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Curso.RazorPages.Pages.Cursos
{
    public class AdicionarAlunoCursoModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdicionarAlunoCursoModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdicionarAlunoCursoViewModel ViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            // Recupere a lista de alunos e o curso específico
            ViewModel = new AdicionarAlunoCursoViewModel
            {
                CursoId = Id,
                Alunos = await _context.Alunos.ToListAsync(),
                Curso = await _context.Cursos.FindAsync(Id)
            };

            return Page();
        }

public async Task<IActionResult> OnPostAsync()
{
    if (ViewModel.AlunoId != null && ViewModel.CursoId != null)
    {
        // Verifique se o aluno e o curso existem no banco de dados
        var aluno = await _context.Alunos.FindAsync(ViewModel.AlunoId);
        var curso = await _context.Cursos.FindAsync(ViewModel.CursoId);

        if (aluno != null && curso != null)
        {
            // Verifique se o relacionamento já existe
            if (!await _context.AlunoCursos.AnyAsync(ac =>
                ac.AlunoId == aluno.AlunoId && ac.CursoId == curso.CursoId))
            {
                // Adicione o relacionamento entre o aluno e o curso
            var alunoCurso = new AlunoCurso
            {
                AlunoId = aluno.AlunoId.GetValueOrDefault(),
                CursoId = curso.CursoId.GetValueOrDefault()
            };


                _context.Add(alunoCurso);
                await _context.SaveChangesAsync();
            }
        }
    }

    return RedirectToPage("Index");
}







    }
}
