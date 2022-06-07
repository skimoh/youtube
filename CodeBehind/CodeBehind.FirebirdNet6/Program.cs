//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.FirebirdNet6.Repository;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Contexto>(x => x.UseFirebird(@"database=C:\GIT\skimoh\CodeBehind\CodeBehind.FirebirdNet6\database\banco.fdb;DataSource=localhost;Dialect=3;Charset=NONE;Pooling=true;user=sysdba;password=masterkey;dialect=3"));
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

builder.Services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
