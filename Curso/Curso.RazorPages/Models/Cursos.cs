using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.RazorPages.Models
{
    public class CursoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CursoId { get; set; }

        [Required(ErrorMessage = "Nome do curso é obrigatório")]
        public string? NomeCurso { get; set; }

        [Required(ErrorMessage = "Descrição do curso é obrigatória")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Data de início do curso é obrigatória")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DataInicio { get; set; }

        [Required(ErrorMessage = "Data de término do curso é obrigatória")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DataTermino { get; set; }

        public List<AlunoModel>? Alunos { get; set; } = new List<AlunoModel>();
    }
}