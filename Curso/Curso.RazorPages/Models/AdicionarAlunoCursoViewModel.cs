using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.RazorPages.Models
{
    public class AdicionarAlunoCursoViewModel
    {
        
        public int AdicionarAlunoCursoViewModelId { get; set; }
        public int? AlunoId { get; set; }
        public int? CursoId { get; set; }
        public List<AlunoModel>? Alunos { get; set; }
        public List<CursoModel>? Cursos { get; set; }
        public CursoModel Curso { get; set; } 
    }

}