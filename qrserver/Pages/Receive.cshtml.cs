using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace qrserver.Pages
{
    public class ReceiveModel : PageModel
    {
        private readonly ILogger<ReceiveModel> _logger;

        public ReceiveModel(ILogger<ReceiveModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
