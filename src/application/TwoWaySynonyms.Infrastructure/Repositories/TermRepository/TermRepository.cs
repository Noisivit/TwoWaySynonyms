using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwoWaySynonyms.DAO.Models;
using TwoWaySynonyms.Domain.Models;
using TwoWaySynonyms.Infrastructure.Database;
using TwoWaySynonyms.InfrastructureContracts.Repositories;
using TwoWaySynonyms.InfrastructureContracts.Services;

namespace TwoWaySynonyms.Infrastructure.Repositories.TermRepository
{
    public class TermRepository : ITermRepository
    {
        private readonly TwoWaySynonymsDbContext _twoWaySynonymsDbContext;
        private readonly ISynonymStructureService _synonymStructureService;

        public TermRepository(TwoWaySynonymsDbContext twoWaySynonymsDbContext, ISynonymStructureService synonymStructureService)
        {
            _twoWaySynonymsDbContext = twoWaySynonymsDbContext;
            _synonymStructureService = synonymStructureService;
        }

        public async Task Add(TermDAO term)
        {
            await _twoWaySynonymsDbContext.AddAsync<TermDAO>(term);

            _twoWaySynonymsDbContext.SaveChanges();
        }

        public async Task<ICollection<Term>> GetStructuredAll()
        {
            var termsDAOsToConvert = await _twoWaySynonymsDbContext.Terms.ToListAsync();

            var result = _synonymStructureService.ConvertTermDAOListToStructuredTermDomain(termsDAOsToConvert);

            return result;
        }
    }
}
