namespace Cursos.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void Add(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
