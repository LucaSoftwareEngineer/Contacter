using Contacter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacter.Services
{
    public interface IContattoService
    {
        Task<IEnumerable<Contatti>> GetAllContattiAsync();
        Task<Contatti?> GetContattoByIdAsync(long id);
        Task<IEnumerable<Contatti>> GetContattiByUserIdAsync(long userId);
        Task<bool> CreateContattoAsync(Contatti contatto);
        Task<bool> UpdateContattoAsync(Contatti contatto);
        Task<bool> DeleteContattoAsync(long id);
    }
}