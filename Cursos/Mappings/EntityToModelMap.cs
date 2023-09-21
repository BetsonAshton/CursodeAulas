using AutoMapper;
using Cursos.Data.Entities;
using Cursos.Models.Authentication;

namespace Cursos.Mappings
{
    public class EntityToModelMap: Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Adm, AuthenticationModel>()
                .AfterMap((entity, model) =>
                {
                    model.DataHoraAcesso = DateTime.Now;
                });
        }
    }
}
