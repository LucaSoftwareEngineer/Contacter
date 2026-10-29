using Contacter.Models;
using Contacter.Services;
using Contacter.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Contacter.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUtenteService _utenteService;

        public AccountController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var existingUser = await _utenteService.GetUtenteByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Questa email è già registrata.");
                return View(model);
            }

            var nuovoUtente = new Utenti { UteEmail = model.Email };
            var success = await _utenteService.CreateUtenteAsync(nuovoUtente, model.Password);

            if (success)
            {
                TempData["SuccessMessage"] = "Registrazione completata! Effettua il login.";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError(string.Empty, "Errore durante la registrazione.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var isValid = await _utenteService.AuthenticateAsync(model.Email, model.Password);
            if (!isValid)
            {
                ModelState.AddModelError(string.Empty, "Email o password errati.");
                return View(model);
            }

            var utente = await _utenteService.GetUtenteByEmailAsync(model.Email);

            // Creazione dei Claims per l'autenticazione tramite Cookie
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, utente!.UteId.ToString()),
                new Claim(ClaimTypes.Email, utente.UteEmail)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Contatti");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}