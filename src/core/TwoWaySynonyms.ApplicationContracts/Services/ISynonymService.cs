using System.Collections.Generic;
using System.Threading.Tasks;
using TwoWaySynonyms.Domain.Models;

namespace TwoWaySynonyms.ApplicationContracts.Services
{
    public interface ISynonymService
    {
        Task AddTermWithSynonyms(string term, string rawSynonyms);

        Task<ICollection<Term>> GetAllTermsWithSynonyms();
    }
}
