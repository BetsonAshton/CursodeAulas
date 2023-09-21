using Microsoft.AspNetCore.Authentication.Cookies;

namespace Cursos.Configurations
{
    public class SecurityConfiguration
    {
        public static void Add(WebApplicationBuilder builder)
        {
            builder.Services.Configure<CookiePolicyOptions>
            (options => { options.MinimumSameSitePolicy = SameSiteMode.None; });

            builder.Services.AddAuthentication
                (CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
        }

        public static void Use(WebApplication app)
        {
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
