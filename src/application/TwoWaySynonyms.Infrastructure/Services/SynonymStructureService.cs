using System.Collections.Generic;
using System.Linq;
using TwoWaySynonyms.DAO.Models;
using TwoWaySynonyms.Domain.Models;
using TwoWaySynonyms.InfrastructureContracts.Services;

namespace TwoWaySynonyms.Infrastructure.Services
{
    public class SynonymStructureService : ISynonymStructureService
    {
        public ICollection<Term> ConvertTermDAOListToStructuredTermDomain(IEnumerable<TermDAO> termDAOs)
        {
            List<Term> structuredTerms = new List<Term>();

            foreach (var termDAO in termDAOs)
            {
                Term term = structuredTerms.FirstOrDefault(t => t.Value.Equals(termDAO.Value));

                if (term == null)
                {
                    term = new Term() { Value = termDAO.Value, Synonyms = new List<Term>() };

                    structuredTerms.Add(term);
                }

                List<string> rawSynonyms = termDAO.RawSynonyms.Split(',').ToList<string>();

                foreach (var stringSynonym in rawSynonyms)
                {
                    var synonym = structuredTerms.FirstOrDefault(t => t.Value.Equals(stringSynonym));

                    if (synonym == null)
                    {
                        synonym = new Term() { Value = stringSynonym, Synonyms = new List<Term>() };

                        structuredTerms.Add(synonym);

                        synonym.Synonyms.Add(term);
                        term.Synonyms.Add(synonym);
                    }
                }

            }

            return structuredTerms;
        }

    }
}
