using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace qrserver.Pages.Upload
{
    public class SuccessModel : PageModel
    {

        private readonly IConfiguration Configuration;
        private string pathToken;
        private string pathFile;
        private ProgramAction action;
        public SuccessModel(IConfiguration configuration)
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
    }
}