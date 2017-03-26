using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YTConvert.CoreWeb.Models
{
    public class ConvertRequest
    {
        [Required]
        public string URL { get; set; }
    }
}
