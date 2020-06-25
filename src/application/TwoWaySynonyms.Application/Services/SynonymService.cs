using System.Collections.Generic;
using System.Threading.Tasks;
using TwoWaySynonyms.ApplicationContracts.Services;
using TwoWaySynonyms.DAO.Models;
using TwoWaySynonyms.Domain.Models;
using TwoWaySynonyms.InfrastructureContracts.Repositories;

namespace TwoWaySynonyms.Application.Services
{
    public class SynonymService : ISynonymService
    {
        private readonly ITermRepository _termRepository;

        public SynonymService(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }

        public async Task AddTermWithSynonyms(string term, string rawSynonyms)
        {
            var newTerm = new TermDAO() { Value = term, RawSynonyms = rawSynonyms };

            await _termRepository.Add(newTerm);
        }

        public async Task<ICollection<Term>> GetAllTermsWithSynonyms()
        {
            return await _termRepository.GetStructuredAll();
        }
    }
}
