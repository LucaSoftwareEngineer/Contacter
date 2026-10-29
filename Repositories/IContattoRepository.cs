using Contacter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacter.Repositories
{
    public interface IContattoRepository
    {
        Task<IEnumerable<Contatti>> GetAllAsync();
        Task<Contatti?> GetByIdAsync(long id);
        Task<IEnumerable<Contatti>> GetByUserIdAsync(long userId);
        Task AddAsync(Contatti contatto);
        void Update(Contatti contatto);
        void Delete(Contatti contatto);
        Task<bool> SaveChangesAsync();
    }
}