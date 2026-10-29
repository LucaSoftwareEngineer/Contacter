using Contacter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacter.Services
{
    public interface IUtenteService
    {
        Task<IEnumerable<Utenti>> GetAllUtentiAsync();
        Task<Utenti?> GetUtenteByIdAsync(long id);
        Task<Utenti?> GetUtenteByEmailAsync(string email);
        Task<bool> CreateUtenteAsync(Utenti utente, string rawPassword); // Modificato per accettare la password in chiaro
        Task<bool> AuthenticateAsync(string email, string rawPassword);   // Nuovo metodo per il login
        Task<bool> UpdateUtenteAsync(Utenti utente);
        Task<bool> DeleteUtenteAsync(long id);
    }
}