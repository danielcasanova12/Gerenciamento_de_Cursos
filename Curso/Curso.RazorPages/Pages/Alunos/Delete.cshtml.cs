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
        public int AlunoId { get; set; }

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

            

            try
            {
                
                _context.Alunos.Remove(alunoToDelete);
                await _context.SaveChangesAsync();
                ViewData["ShowSuccessAlert"] = true;
            }
            catch (Exception)
            {
                ViewData["MensagemErro"] = "Não é possível excluir o aluno, pois ele está matriculado em cursos.";
            }
            var alunoModel = await _context.Alunos.FirstOrDefaultAsync(a => a.AlunoId == id);
        if (alunoModel != null)
        {
            AlunoToDelete = alunoModel;
        }
            // Recarregue a página para mostrar as mensagens
            return Page();
        }


            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null || _context.Alunos == null)
                {
                    return NotFound();
                }

                AlunoId = id.Value;  // Atribua o ID do aluno à propriedade AlunoId

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
