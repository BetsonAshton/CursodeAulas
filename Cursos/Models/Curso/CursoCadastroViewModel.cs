using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Curso
{
    public class CursoCadastroViewModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do Curso.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data do curso.")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor do curso.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Por favor, selecione o professor do curso.")]
        public Guid? IdProfessor { get; set; }
    }
}
