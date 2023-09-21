using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Data.Entities
{
    public class Adm
    {
        private Guid? _idAdm;
        private string? _nome;
        private string? _email;
        private string? _senha;
        private DateTime? _dataCriacao;

        private List<Professor>? _professor;
        private List<Curso>? _cursos;

        public Guid? IdAdm { get => _idAdm; set => _idAdm = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Senha { get => _senha; set => _senha = value; }
        public DateTime? DataCriacao { get => _dataCriacao; set => _dataCriacao = value; }
        public List<Professor>? Professor { get => _professor; set => _professor = value; }
        public List<Curso>? Cursos { get => _cursos; set => _cursos = value; }
    }
}
