using System.Collections.Generic;
using TwoWaySynonyms.DAO.Models;
using TwoWaySynonyms.Domain.Models;

namespace TwoWaySynonyms.InfrastructureContracts.Services
{
    public interface ISynonymStructureService
    {
        public ICollection<Term> ConvertTermDAOListToStructuredTermDomain(IEnumerable<TermDAO> termDAOs);
    }
}
