using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.RazorPages.Models;
using Curso.RazorPages.Data; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cursos.RazorPages.Pages.Cursos // Certifique-se de que o namespace esteja correto
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public CursoModel CursoToEdit { get; set; } = new CursoModel(); // Use a classe Curso para representar os cursos

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

            var cursoToEdit = await _context.Cursos.FindAsync(id);
            if (cursoToEdit == null)
            {
                return NotFound();
            }

            cursoToEdit.NomeCurso = CursoToEdit.NomeCurso;
            cursoToEdit.Descricao = CursoToEdit.Descricao;
            cursoToEdit.DataInicio = CursoToEdit.DataInicio;
            cursoToEdit.DataTermino = CursoToEdit.DataTermino;

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
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos.FirstOrDefaultAsync(c => c.CursoId == id);
            if (cursoModel == null)
            {
                return NotFound();
            }

            CursoToEdit = cursoModel;

            return Page();
        }
    }
}
