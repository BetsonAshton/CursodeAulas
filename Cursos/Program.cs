using Cursos.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
AutoMapperConfiguration.Add(builder);
SecurityConfiguration.Add(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<CacheConfiguration>();

SecurityConfiguration.Use(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Adm}/{action=Login}/{id?}");

app.Run();
