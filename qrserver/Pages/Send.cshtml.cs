using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace qrserver.Pages
{
    public class SendModel : PageModel
    {
        private readonly ILogger<SendModel> _logger;

        public SendModel(ILogger<SendModel> logger)
        {
            _logger = logger;
        }
        


        public void OnGet()
        {

        }
    }
}
