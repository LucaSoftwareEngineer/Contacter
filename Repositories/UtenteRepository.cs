using Contacter.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacter.Repositories
{
    public class UtenteRepository : IUtenteRepository
    {
        private readonly DevContacterContext _context;

        public UtenteRepository(DevContacterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Utenti>> GetAllAsync()
        {
            return await _context.Utentis.Include(u => u.Contattis).ToListAsync();
        }

        public async Task<Utenti?> GetByIdAsync(long id)
        {
            return await _context.Utentis
                .Include(u => u.Contattis)
                .FirstOrDefaultAsync(u => u.UteId == id);
        }

        public async Task<Utenti?> GetByEmailAsync(string email)
        {
            return await _context.Utentis
                .FirstOrDefaultAsync(u => u.UteEmail == email);
        }

        public async Task AddAsync(Utenti utente)
        {
            await _context.Utentis.AddAsync(utente);
        }

        public void Update(Utenti utente)
        {
            _context.Utentis.Update(utente);
        }

        public void Delete(Utenti utente)
        {
            _context.Utentis.Remove(utente);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}