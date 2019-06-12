using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CO.Web.Controllers
{
    public class WebPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}