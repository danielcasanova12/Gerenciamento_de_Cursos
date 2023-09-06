using System;
using System.Threading.Tasks;
using Curso.RazorPages.Data;
using Curso.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cursos.RazorPages.Pages.Alunos
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public AlunoModel AlunoDetails { get; set; } = new AlunoModel();

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Alunos.Add(AlunoDetails);
                _context.SaveChanges();
                var criaAlunoComSucesso = true; 

                ViewData["ShowSuccessAlert"] = true;
                return Page();
                
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "Erro ao criar o aluno.";
                return Page();
            }
        }


    }
}
