using System.Collections.Generic;

namespace TwoWaySynonyms.Domain.Models
{
    public class Term
    {
        public string Value { get; set; }
        public ICollection<Term> Synonyms { get; set; }
    }
}
