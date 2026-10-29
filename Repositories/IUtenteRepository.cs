using Contacter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacter.Repositories
{
    public interface IUtenteRepository
    {
        Task<IEnumerable<Utenti>> GetAllAsync();
        Task<Utenti?> GetByIdAsync(long id);
        Task<Utenti?> GetByEmailAsync(string email);
        Task AddAsync(Utenti utente);
        void Update(Utenti utente);
        void Delete(Utenti utente);
        Task<bool> SaveChangesAsync();
    }
}