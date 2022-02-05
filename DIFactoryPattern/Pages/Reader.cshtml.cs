using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DIFactoryPattern.Pages
{
    public class ReaderModel : PageModel
    {
        private readonly IDocumentProcessorFactory documentProcessorFactory;
        [BindProperty]
        public string Type { get; set; }
        public string Data { get; set; }
        public ReaderModel(IDocumentProcessorFactory documentProcessorFactory)
        {
            this.documentProcessorFactory = documentProcessorFactory;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var res = documentProcessorFactory.Create(this.Type);
            Data = res.Process();
            return Page();
        }
    }
}
