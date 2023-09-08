using System.ComponentModel.DataAnnotations;

namespace Curso.RazorPages.Models
{
    public class AlunoCurso
    {
        [Key]
        public int? AlunoCursoId { get; set; }

        public int? AlunoId { get; set; }
        public AlunoModel? Aluno { get; set; }

        public int? CursoId { get; set; }
        public CursoModel? Curso { get; set; }
    }
}
