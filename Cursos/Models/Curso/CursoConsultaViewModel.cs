using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Curso
{
    public class CursoConsultaViewModel
    {
        public Guid IdCurso { get; set; }


        public string? Nome { get; set; }


        public DateTime? Data { get; set; }

        public decimal? Valor { get; set; }

        public Guid? IdProfessor { get; set; }

        public string? Professor { get; set; }
    }
}
