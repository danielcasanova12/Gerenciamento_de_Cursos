using System;
using System.Threading.Tasks;
using Curso.RazorPages.Data;
using Curso.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cursos.RazorPages.Pages.Alunos
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public AlunoModel AlunoToEdit { get; set; } = new AlunoModel();

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var alunoToEdit = await _context.Alunos.FindAsync(id);
            if (alunoToEdit == null)
            {
                return NotFound();
            }

            alunoToEdit.NomeAluno = AlunoToEdit.NomeAluno;
            alunoToEdit.Email = AlunoToEdit.Email;

            try
            {
                await _context.SaveChangesAsync();
                ViewData["ShowSuccessAlert"] = true;
                return Page();
            }
            catch (Exception)
            {
                 ViewData["MensagemErro"] = "Não é possível excluir o aluno, pois ele está matriculado em cursos.";
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

            AlunoToEdit = alunoModel;

            return Page();
        }
    }
}
