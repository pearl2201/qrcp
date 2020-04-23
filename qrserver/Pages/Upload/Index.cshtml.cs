using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using qrserver.ModelView;

namespace qrserver.Pages.Upload
{
    public class IndexModel : PageModel
    {

        private readonly IConfiguration Configuration;
        private string pathToken;
        private string pathFile;
        private ProgramAction action;
        public IndexModel(IConfiguration configuration)
        {
            Configuration = configuration;

            pathToken = Configuration["PathToken"];
            pathFile = Configuration["PathFile"];
            action = Configuration["Action"] == ProgramAction.SEND.ToString() ? ProgramAction.SEND : ProgramAction.RECEIVE;

        }


        public IActionResult OnGet()
        {
            if (action != ProgramAction.RECEIVE)
            {
                return NotFound();
                
            }
            return Page();
        }

        [BindProperty]
        public UploadFile Post { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (action != ProgramAction.RECEIVE)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var memoryStream = System.IO.File.Create(pathFile))
            {
                await Post.File.CopyToAsync(memoryStream);
            }
            return RedirectToPage("./Success");
        }
    }
}