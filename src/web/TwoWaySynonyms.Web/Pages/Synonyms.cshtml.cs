using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwoWaySynonyms.ApplicationContracts.Services;
using TwoWaySynonyms.Domain.Models;

namespace TwoWaySynonyms.Web.Pages
{
    public class SynonymsModel : PageModel
    {
        [BindProperty]
        public ICollection<Term> Terms { get; set; }

        private readonly ILogger<SynonymsModel> _logger;
        private readonly ISynonymService _synonymService;

        public SynonymsModel(ILogger<SynonymsModel> logger, ISynonymService synonymService)
        {
            _logger = logger;
            _synonymService = synonymService;
        }

        public async Task OnGet()
        {
            Terms = await _synonymService.GetAllTermsWithSynonyms();
        }

        public async Task<IActionResult> OnPostAddTermWithSynonyms(string term, string synonyms)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _synonymService.AddTermWithSynonyms(term, synonyms);

            _logger.LogInformation("New terms with synonyms was added.");

            return RedirectToPage("Synonyms");
        }
    }
}