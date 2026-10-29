using Contacter.Models;
using Contacter.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacter.Services
{
    public class ContattoService : IContattoService
    {
        private readonly IContattoRepository _contattoRepository;

        public ContattoService(IContattoRepository contattoRepository)
        {
            _contattoRepository = contattoRepository;
        }

        public async Task<IEnumerable<Contatti>> GetAllContattiAsync()
        {
            return await _contattoRepository.GetAllAsync();
        }

        public async Task<Contatti?> GetContattoByIdAsync(long id)
        {
            return await _contattoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Contatti>> GetContattiByUserIdAsync(long userId)
        {
            return await _contattoRepository.GetByUserIdAsync(userId);
        }

        public async Task<bool> CreateContattoAsync(Contatti contatto)
        {
            await _contattoRepository.AddAsync(contatto);
            return await _contattoRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateContattoAsync(Contatti contatto)
        {
            _contattoRepository.Update(contatto);
            return await _contattoRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteContattoAsync(long id)
        {
            var contatto = await _contattoRepository.GetByIdAsync(id);
            if (contatto == null) return false;

            _contattoRepository.Delete(contatto);
            return await _contattoRepository.SaveChangesAsync();
        }
    }
}