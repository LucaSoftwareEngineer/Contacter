using Contacter.Models;
using Contacter.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacter.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly IUtenteRepository _utenteRepository;
        private readonly IPasswordHasher<Utenti> _passwordHasher;

        public UtenteService(IUtenteRepository utenteRepository, IPasswordHasher<Utenti> passwordHasher)
        {
            _utenteRepository = utenteRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<Utenti>> GetAllUtentiAsync()
        {
            return await _utenteRepository.GetAllAsync();
        }

        public async Task<Utenti?> GetUtenteByIdAsync(long id)
        {
            return await _utenteRepository.GetByIdAsync(id);
        }

        public async Task<Utenti?> GetUtenteByEmailAsync(string email)
        {
            return await _utenteRepository.GetByEmailAsync(email);
        }

        public async Task<bool> CreateUtenteAsync(Utenti utente, string rawPassword)
        {
            utente.UtePass = _passwordHasher.HashPassword(utente, rawPassword);

            await _utenteRepository.AddAsync(utente);
            return await _utenteRepository.SaveChangesAsync();
        }

        public async Task<bool> AuthenticateAsync(string email, string rawPassword)
        {
            var utente = await _utenteRepository.GetByEmailAsync(email);
            if (utente == null)
            {
                return false;
            }

            var result = _passwordHasher.VerifyHashedPassword(utente, utente.UtePass, rawPassword);

            return result == PasswordVerificationResult.Success;
        }

        public async Task<bool> UpdateUtenteAsync(Utenti utente)
        {
            _utenteRepository.Update(utente);
            return await _utenteRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteUtenteAsync(long id)
        {
            var utente = await _utenteRepository.GetByIdAsync(id);
            if (utente == null) return false;

            _utenteRepository.Delete(utente);
            return await _utenteRepository.SaveChangesAsync();
        }
    }
}