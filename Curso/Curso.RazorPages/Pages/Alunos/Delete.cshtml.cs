using System;
using System.Threading.Tasks;
using Curso.RazorPages.Data;
using Curso.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cursos.RazorPages.Pages.Alunos
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public AlunoModel AlunoToDelete { get; set; } = new AlunoModel();

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var alunoToDelete = await _context.Alunos.FindAsync(id);
            if (alunoToDelete == null)
            {
                return NotFound();
            }

            // Verifique se o aluno está matriculado em algum curso
            bool alunoEstaMatriculado = _context.AlunoCursos.Any(ac => ac.AlunoId == id);

            if (alunoEstaMatriculado)
            {
                // O aluno está matriculado em cursos, mostrar mensagem de erro ou fazer o tratamento apropriado
                TempData["MensagemErro"] = "Não é possível excluir o aluno, pois ele está matriculado em cursos.";
            }

            try
            {
                _context.Alunos.Remove(alunoToDelete);
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
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.Alunos.FirstOrDefaultAsync(a => a.AlunoId == id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            AlunoToDelete = alunoModel;

            return Page();
        }
    }
}
