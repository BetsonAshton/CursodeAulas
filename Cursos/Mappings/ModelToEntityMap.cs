using AutoMapper;
using Cursos.Data.Entities;
using Cursos.Data.Helpers;
using Cursos.Models;
using Cursos.Models.Curso;
using Cursos.Models.Professor;

namespace Cursos.Mappings
{
    public class ModelToEntityMap: Profile
    {
        public ModelToEntityMap() 
        {
            CreateMap<RegisterViewModel, Adm>()
              .AfterMap((model, entity) =>
              {
                  entity.IdAdm= Guid.NewGuid();
                  entity.Senha = MD5Cryptography.Hash(model.Senha);
                  entity.DataCriacao = DateTime.Now;
                  
              });

            CreateMap<ProfessorCadastroViewModel, Professor>()
               .AfterMap((model, entity) =>
               {
                   entity.IdProfessor = Guid.NewGuid();
               });

            CreateMap<CursoCadastroViewModel, Curso>()
              .AfterMap((model, entity) =>
              {
                  entity.IdCurso = Guid.NewGuid();
              });


        }
    }
}
