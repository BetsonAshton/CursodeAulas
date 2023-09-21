using Cursos.Data.Contexts;
using Cursos.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Data.Repositories
{
    public class CursoRepository : BaseRepository<Curso, Guid>
    {
        public override Curso? Obter(Func<Curso, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Curso
                    .Include(c => c.Professor) // Include related Professor entity
                    .FirstOrDefault(where);
            }
        }

        public override Curso? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Curso
                    .Include(c => c.Professor) // Include related Professor entity
                    .FirstOrDefault(c => c.IdCurso == id);
            }
        }

        public override List<Curso> ObterTodos(Func<Curso, bool> where = null)
        {
            using (var dataContext = new DataContext())
            {
                var query = dataContext.Curso.Include(c => c.Professor);

                if (where != null)
                    query = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Curso, Professor?>)query.Where(where);

                return query.ToList();
            }
        }
    }
}
