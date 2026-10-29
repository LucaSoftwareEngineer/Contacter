using Contacter.Models;
using Contacter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Contacter.Controllers
{
    [Authorize]
    public class ContattiController : Controller
    {
        private readonly IContattoService _contattoService;

        public ContattiController(IContattoService contattoService)
        {
            _contattoService = contattoService;
        }

        private long GetCurrentUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? long.Parse(claim.Value) : 0;
        }

        public async Task<IActionResult> Index()
        {
            long userId = GetCurrentUserId();
            var contatti = await _contattoService.GetContattiByUserIdAsync(userId);
            return View(contatti);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Contatti contatto)
        {
            contatto.ConUteId = GetCurrentUserId();
            ModelState.Remove("ConUte"); // Rimuoviamo la validazione della navigation property

            if (ModelState.IsValid)
            {
                await _contattoService.CreateContattoAsync(contatto);
                return RedirectToAction(nameof(Index));
            }
            return View(contatto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            await _contattoService.DeleteContattoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}