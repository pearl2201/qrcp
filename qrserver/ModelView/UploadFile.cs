using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qrserver.ModelView
{
    public class UploadFile
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile File { get; set; }
    }
}
