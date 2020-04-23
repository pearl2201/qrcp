using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace qrserver.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {

        private readonly IConfiguration Configuration;
        private string pathToken;
        private string pathFile;
        private ProgramAction action;
        public SendController(IConfiguration configuration)
        {
            Configuration = configuration;

            pathToken = Configuration["PathToken"];
            pathFile = Configuration["PathFile"];
            action = Configuration["Action"] == ProgramAction.SEND.ToString() ? ProgramAction.SEND : ProgramAction.RECEIVE;
        }

        [HttpGet("{token}")]
        public IActionResult Get(string token)
        {
            if (action != ProgramAction.SEND)
                return NotFound();
            if (!string.Equals(pathToken, token, StringComparison.InvariantCultureIgnoreCase))
            {
                return NotFound();
            }
            var stream = System.IO.File.OpenRead(pathFile);

            if (stream == null)
                return NotFound(); // returns a NotFoundResult with Status404NotFound response.

            return new FileStreamResult(stream, "application/octet-stream"); 
        }

    }
}