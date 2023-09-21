using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Data.Entities
{
     public class Professor
    {
        private Guid? _idProfessor;
        private string? _nome;
        private Guid? _idAdm;

        private Adm? _adm;
        private List<Curso>? _cursos;

        public Guid? IdProfessor { get => _idProfessor; set => _idProfessor = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public Guid? IdAdm { get => _idAdm; set => _idAdm = value; }
        public Adm? Adm { get => _adm; set => _adm = value; }
        public List<Curso>? Cursos { get => _cursos; set => _cursos = value; }
    }
}
