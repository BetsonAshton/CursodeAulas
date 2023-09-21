using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Professor
{
    public class ProfessorEdicaoViewModel
    {
        public Guid? IdProfessor { get; set; }

        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{8,50}$",
          ErrorMessage = "Por favor, informe um nome válido de 8 a 50 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome da categoria.")]
        public string? Nome { get; set; }
    }
}
