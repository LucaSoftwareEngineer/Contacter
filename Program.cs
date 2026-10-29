using Contacter.Models;
using Contacter.Repositories;
using Contacter.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurazione del Database (DbContext)
builder.Services.AddDbContext<DevContacterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurazione dell'Autenticazione tramite Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Specifica dove reindirizzare l'utente se non è autenticato e prova a visitare pagine protette
        options.LoginPath = "/Account/Login";
        // Durata del cookie di autenticazione
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        // Eventuale pagina di accesso negato
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// Registrazione di Repository, Services e PasswordHasher
builder.Services.AddScoped<IUtenteRepository, UtenteRepository>();
builder.Services.AddScoped<IContattoRepository, ContattoRepository>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IContattoService, ContattoService>();
builder.Services.AddScoped<IPasswordHasher<Utenti>, PasswordHasher<Utenti>>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();