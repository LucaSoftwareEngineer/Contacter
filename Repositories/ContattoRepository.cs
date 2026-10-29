using Contacter.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacter.Repositories
{
    public class ContattoRepository : IContattoRepository
    {
        private readonly DevContacterContext _context;

        public ContattoRepository(DevContacterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contatti>> GetAllAsync()
        {
            return await _context.Contattis
                .Include(c => c.ConUte)
                .ToListAsync();
        }

        public async Task<Contatti?> GetByIdAsync(long id)
        {
            return await _context.Contattis
                .Include(c => c.ConUte)
                .FirstOrDefaultAsync(c => c.ConId == id);
        }

        public async Task<IEnumerable<Contatti>> GetByUserIdAsync(long userId)
        {
            return await _context.Contattis
                .Where(c => c.ConUteId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Contatti contatto)
        {
            await _context.Contattis.AddAsync(contatto);
        }

        public void Update(Contatti contatto)
        {
            _context.Contattis.Update(contatto);
        }

        public void Delete(Contatti contatto)
        {
            _context.Contattis.Remove(contatto);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}