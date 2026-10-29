using Contacter.Models;
using Contacter.Repositories;
using Contacter.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurazione di Entity Framework Core con SQL Server
builder.Services.AddDbContext<DevContacterContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrazione dei Repository
builder.Services.AddScoped<IUtenteRepository, UtenteRepository>();
builder.Services.AddScoped<IContattoRepository, ContattoRepository>();

// Registrazione del PasswordHasher nativo di ASP.NET Core
builder.Services.AddScoped<IPasswordHasher<Utenti>, PasswordHasher<Utenti>>();

// Registrazione dei Service
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IContattoService, ContattoService>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IContattoService, ContattoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();