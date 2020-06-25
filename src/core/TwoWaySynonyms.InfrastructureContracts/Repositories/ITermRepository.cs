using System.Collections.Generic;
using System.Threading.Tasks;
using TwoWaySynonyms.DAO.Models;
using TwoWaySynonyms.Domain.Models;

namespace TwoWaySynonyms.InfrastructureContracts.Repositories
{
    public interface ITermRepository
    {
        Task Add(TermDAO term);
        Task<ICollection<Term>> GetStructuredAll();
    }
}
