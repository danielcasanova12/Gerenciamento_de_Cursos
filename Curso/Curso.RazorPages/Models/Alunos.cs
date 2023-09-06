using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.RazorPages.Models
{
    public class AlunoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? AlunoId { get; set; }

        [Required(ErrorMessage = "Nome do aluno é obrigatório")]
        public string? NomeAluno { get; set; }

        [Required(ErrorMessage = "E-mail do aluno é obrigatório")]
        public string? Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
        public DateTime? DataInscricao { get; set; }

        public List<CursoModel>? Cursos { get; set; }
    }
}