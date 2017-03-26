using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YTConvert.CoreWeb.Models;

namespace YTConvert.CoreWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Convert(ConvertRequest cRequest)
        {
            if (ModelState.IsValid)
            {
                //SendConvertRequest(cRequest);
            }
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
