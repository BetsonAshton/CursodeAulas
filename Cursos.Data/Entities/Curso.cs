using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Data.Entities
{
    public class Curso
    {

        private Guid? _idCurso;
        private string? _nome;
        private decimal? _valor;
        private DateTime? _data;
        private Guid? _idAdm;
        private Guid? _idProfessor;

        private Adm? _adm;
        private Professor? _professor;

        public Guid? IdCurso { get => _idCurso; set => _idCurso = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public decimal? Valor { get => _valor; set => _valor = value; }
        public DateTime? Data { get => _data; set => _data = value; }
        public Guid? IdAdm { get => _idAdm; set => _idAdm = value; }
        public Guid? IdProfessor { get => _idProfessor; set => _idProfessor = value; }
        public Adm? Adm { get => _adm; set => _adm = value; }
        public Professor? Professor { get => _professor; set => _professor = value; }
    }
}
